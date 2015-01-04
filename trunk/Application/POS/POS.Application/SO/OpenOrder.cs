using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.Utilities;
using POS.BL;
using POS.BL.Entities.Entity;
using POS.Control;
using Core.Standards.Converters;
using POS.BL.DTO.SO;
namespace POS.SO
{
    public partial class OpenOrder : Control.FormBase
    {
        List<OrderDTO> OrderList;
        private OrderHeadDTO _OrderHeads;
        public OrderHeadDTO OrderHeads
        {
            get
            {
                if (_OrderHeads == null)
                {
                    _OrderHeads = new OrderHeadDTO();
                }
                return _OrderHeads;
            }
            set
            {
                if (_OrderHeads == null)
                {
                    _OrderHeads = new OrderHeadDTO();
                }
                _OrderHeads = value;
            }
        }

        public OpenOrder()
        {
            InitializeComponent();
            base.BindConfigScreen(pnlNumScreen, ControlCode.OpenOrder, txtCommand);

            lisMenuOrder.Columns.Add("Menu Name", 250, HorizontalAlignment.Left);
            lisMenuOrder.Columns.Add("Oty", 50, HorizontalAlignment.Right);
            lisMenuOrder.Columns.Add("Price", -2, HorizontalAlignment.Right);

            lisMenuOrder.View = View.Details;
            this.LoadDiningType();
        }

        private void LoadDiningType()
        {
            List<DiningType> listDining = ServiceProvider.DiningTypeService.FindDinningTypeActive();
            if (listDining != null && listDining.Count > 0)
            {
                fPnlDiningType.Controls.Clear();
                foreach (DiningType Diningitem in listDining)
                {
                    BaseButton btnDining = new BaseButton();
                    btnDining.Width = 150;
                    btnDining.Height = 60;
                    btnDining.Text = Diningitem.dining_type_name;
                    btnDining.CommandArg = Diningitem.dining_type_id.Value.ToString();
                    btnDining.Theme = Theme.MSOffice2010_BLUE;
                    btnDining.Click += new EventHandler(btnDiningi_Click);
                    btnDining.Font = new System.Drawing.Font(DefaultFontControl.FontName, DefaultFontControl.FontSize, FontStyle.Bold);
                    fPnlDiningType.Controls.Add(btnDining);
                }

            }
        }



        private void LoadMenuToContaner(long diningTypeId)
        {
            List<OrderDTO> mainMenu = ServiceProvider.MenuService.LoadMainMenu(new SOMenu(), diningTypeId);
            this.BindMenu(mainMenu, fPnlMainMenu, Theme.MSOffice2010_RED);
        }

        private void BindMenu(List<OrderDTO> mainMenu, FlowLayoutPanel flowPanel, POS.Control.Theme t)
        {
            if (mainMenu != null && mainMenu.Count > 0)
            {
                flowPanel.Controls.Clear();
                foreach (OrderDTO Menuitem in mainMenu)
                {
                    BaseButton btnMenu = new BaseButton();
                    btnMenu.Width = 150;
                    btnMenu.Height = 70;
                    btnMenu.Text = Menuitem.menu_name;
                    btnMenu.CommandArg = Menuitem.menu_id.ToString();
                    btnMenu.DataObject = Menuitem;
                    if (ServiceProvider.MenuService.HaveMinuItem(Menuitem.menu_id))
                    {
                        btnMenu.Click += new EventHandler(btnMenu_Click);
                        btnMenu.Theme = t;
                    }
                    else
                    {
                        btnMenu.Click += new EventHandler(btnMenuItem_Click);
                        if (Menuitem.isInventoryItem)
                        {
                            btnMenu.Theme = Theme.MSOffice2010_RED;
                        }
                        else
                        {
                            btnMenu.Theme = Theme.MSOffice2010_Green;
                        }
                    }
                    btnMenu.Font = new System.Drawing.Font(DefaultFontControl.FontName, DefaultFontControl.FontSize, FontStyle.Bold);


                    flowPanel.Controls.Add(btnMenu);
                }
            }
        }
        private void AddMenu()
        {

            if (lisMenuOrder.SelectedItems.Count > 0)
            {
                this.OrderList.ForEach(a => a.Selected = false);
                ListViewItem addItem = lisMenuOrder.SelectedItems[0];
                long sales_order_detail_id = Converts.ParseLong(addItem.Name);
                OrderDTO updateItem = this.OrderList.Where(a => a.sales_order_detail_id == sales_order_detail_id).FirstOrDefault();
                if (updateItem != null && updateItem.OrderState == ObjectState.Add)
                {
                    updateItem.order_amount = updateItem.order_amount += 1;
                    updateItem.Selected = true;

                }
                this.BindListOrder();
            }
        }
        private void DeleteMenu()
        {
            if (lisMenuOrder.SelectedItems.Count > 0)
            {
                ListViewItem delItem = lisMenuOrder.SelectedItems[0];
                long sales_order_detail_id = Converts.ParseLong(delItem.Name);
                OrderDTO updateItem = this.OrderList.Where(a => a.sales_order_detail_id == sales_order_detail_id).FirstOrDefault();
                updateItem.order_amount = updateItem.order_amount - 1;

                if (updateItem.order_amount <= 0)
                {
                    if (updateItem != null && updateItem.OrderState == ObjectState.Add)
                    {
                        this.OrderList.Remove(updateItem);

                    }
                    else if (updateItem != null && updateItem.OrderState == ObjectState.Edit)
                    {
                        updateItem.OrderState = ObjectState.Delete;
                    }
                }
                else
                {
                    updateItem.Selected = true;
                }
                this.BindListOrder();
            }
        }

        #region  :: Event Button ::
        protected void btnDiningi_Click(object sender, EventArgs e)
        {
            BaseButton btnDining = sender as BaseButton;
            fPnlMenuItem.Controls.Clear();
            fPnlMainMenu.Controls.Clear();
            this.LoadMenuToContaner(Converts.ParseLong(btnDining.CommandArg));
        }
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            BaseButton btnMenu = sender as BaseButton;
            SOMenu mainMenu = new SOMenu();
            mainMenu.menu_reference_id = Converts.ParseLongNullable(btnMenu.CommandArg);

            List<OrderDTO> mainMenuList = ServiceProvider.MenuService.LoadMainMenu(mainMenu);
            this.BindMenu(mainMenuList, fPnlMenuItem, Theme.MSOffice2010_BLUE);
        }

        protected void btnMenuItem_Click(object sender, EventArgs e)
        {
            if (this.OrderList == null)
            {
                this.OrderList = new List<OrderDTO>();
            }

            BaseButton btnMenu = sender as BaseButton;
            OrderDTO MenuItem = new OrderDTO();
            MenuItem = btnMenu.DataObject as OrderDTO;


            int menuCount = Converts.ParseInt(txtCommand.Text);
            if (menuCount == 0)
            {
                menuCount = 1;
            }


            long orderDetailId = -1;
            long minId = this.OrderList.Count > 0 ? this.OrderList.Min(a => a.sales_order_detail_id).Value : 0;
            if (minId > 0)
            {
                orderDetailId = -1;
            }
            else
            {
                orderDetailId = minId - 1;
            }



            OrderDTO OrderItem = new OrderDTO();
            OrderItem.sales_order_detail_id = orderDetailId;
            OrderItem.order_amount = menuCount;
            OrderItem.menu_price = MenuItem.menu_price;
            OrderItem.menu_id = MenuItem.menu_id;
            OrderItem.menu_dining_type_id = MenuItem.menu_dining_type_id;
            OrderItem.menu_name = MenuItem.menu_name;

            // Chekc Is Inver item?
            if (MenuItem.isInventoryItem)
            {
                OrderDTO ItemInven = this.OrderList.Where(i => i.menu_id == MenuItem.menu_id).FirstOrDefault();
                if (ItemInven != null)
                {
                    ItemInven.order_amount += menuCount;
                }
                else
                {
                    this.OrderList.Add(OrderItem);
                }

            }
            else
            {
                this.OrderList.Add(OrderItem);
            }
            this.BindListOrder();
            txtCommand.Text = string.Empty;
        }
        private void BindListOrder()
        {
            lisMenuOrder.Items.Clear();
            foreach (OrderDTO Orderitem in this.OrderList.Where(o => o.OrderState != ObjectState.Delete))
            {
                ListViewItem item = new ListViewItem(Orderitem.menu_name);
                item.SubItems.Add(Orderitem.order_amount.ToString());
                item.SubItems.Add(Orderitem.TotalAmount.ToString());
                item.Name = Orderitem.sales_order_detail_id.ToString();
                item.Selected = Orderitem.Selected;
                lisMenuOrder.Items.Add(item);
                if (Orderitem.Selected)
                {
                    lisMenuOrder.Select();
                }
            }
            labTotalPrice.Text = string.Format(Format.DecimalNumberFormat2DZero, this.OrderList.Sum(a => a.TotalAmount));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.AddMenu();

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteMenu();

        }


        private void lisMenuOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lisMenuOrder.SelectedItems.Count > 0)
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Theme = Theme.MSOffice2010_Green;
                btnDelete.Theme = Theme.MSOffice2010_RED;

            }
            else
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnAdd.Theme = Theme.MSOffice2010_WHITE;
                btnDelete.Theme = Theme.MSOffice2010_WHITE;
            }
            btnAdd.Invalidate();
            btnDelete.Invalidate();
        }
        private void btnStartTime_Click(object sender, EventArgs e)
        {
            this.OrderHeads.IsStartTime = true;
            btnStartTime.Theme = Theme.MSOffice2010_WHITE;
            btnStartTime.Invalidate();
            btnStartTime.Enabled = false;
            timeEating.Start();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
          
        }
        #endregion

        private void btnPerson_Click(object sender, EventArgs e)
        {
            using (PopUpPerson form = new PopUpPerson())
            {
                form.openPopupHandler += new PopUpPerson.OpenPupupHandler(form_openPopupHandler);
                form.closePopupHandler += new PopUpPerson.ClosePopupHandler(form_closePopupHandler);
                DialogResult result = form.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.Show();
                    this.Activate();
                }

            }
        }

        protected void form_closePopupHandler(OrderHeadDTO orderHead)
        {
            this.OrderHeads = orderHead;
            labPersonCount.Text = this.OrderHeads.Person.ToString();
        }

        protected OrderHeadDTO form_openPopupHandler()
        {
            return this.OrderHeads;
        }

        private void timeEating_Tick(object sender, EventArgs e)
        {
            if (this.OrderHeads.IsStartTime) {
                TimeSpan dateDiff = (DateTime.Now - this.OrderHeads.StartTimeEating.Value);
                labEatingTime.Text = dateDiff.ToString(@"hh\:mm\:ss");//string.Format("{0:c}", dateDiff);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.CloseScreen();
        }




    }

}
