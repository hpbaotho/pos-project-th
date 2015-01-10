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
                    btnDining.DataObject = Diningitem;
                    btnDining.Theme = Theme.MSOffice2010_BLUE;
                    btnDining.Click += new EventHandler(btnDiningi_Click);
                    btnDining.Font = new System.Drawing.Font(DefaultFontControl.FontName, DefaultFontControl.FontSize, FontStyle.Bold);
                    fPnlDiningType.Controls.Add(btnDining);
                }

            }
        }



        private void LoadMenuToContaner(long? diningTypeId,long? menuGroupId,long? menuCategoryId)
        {
            List<OrderDTO> mainMenu = ServiceProvider.MenuService.LoadMainMenu(null, diningTypeId, menuGroupId, menuCategoryId);
            this.BindMenu(mainMenu, fPnlMenuItem, Theme.MSOffice2010_RED);
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
                    if (ServiceProvider.MenuService.HaveMinuItem(Menuitem.menu_id, Menuitem.menu_dining_type_id, Menuitem.menu_group_id, Menuitem.menu_category_id))
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

            if (btnDining != null)
            {
                DiningType diningSelect = btnDining.DataObject as DiningType;
                List<MenuGroup> menuGroup = ServiceProvider.MenuGroupService.FindByDiningType(diningSelect.dining_type_id.Value);
                if (menuGroup != null && menuGroup.Count > 0)
                {


                    foreach (MenuGroup MenuGroupitem in menuGroup)
                    {
                        BaseButton btnMenuGroup = new BaseButton();
                        btnMenuGroup.Width = 150;
                        btnMenuGroup.Height = 70;
                        btnMenuGroup.Theme = Theme.MSOffice2010_Violet;
                        btnMenuGroup.Text = MenuGroupitem.menu_group_name;
                        btnMenuGroup.DataObject = MenuGroupitem;
                        btnMenuGroup.Click += new EventHandler(btnMenuGroup_Click);
                        btnMenuGroup.Font = new System.Drawing.Font(DefaultFontControl.FontName, DefaultFontControl.FontSize, FontStyle.Bold);

                        fPnlMainMenu.Controls.Add(btnMenuGroup);
                    }
                }
            }
          
        }

        protected void btnMenuGroup_Click(object sender, EventArgs e)
        {
            BaseButton btnMenuGroup = sender as BaseButton;
            fPnlMenuItem.Controls.Clear();
            fPnlMainMenu.Controls.Clear();
            if (btnMenuGroup != null)
            {
                MenuGroup MenuGroupSelect = btnMenuGroup.DataObject as MenuGroup;
                List<MenuCategory> menuCatagory = ServiceProvider.MenuCategoryService.FindByMenuGroup(MenuGroupSelect.menu_group_id.Value, MenuGroupSelect.dining_type_id.Value);
                if (menuCatagory != null && menuCatagory.Count > 0)
                {
                    foreach (MenuCategory MenuCategoryitem in menuCatagory)
                    {
                        MenuCategoryitem.menu_group_id = MenuGroupSelect.menu_group_id;
                        BaseButton btnCategory = new BaseButton();
                        btnCategory.Theme=Theme.MSOffice2010_Yellow;
                        btnCategory.Width = 150;
                        btnCategory.Height = 70;
                        btnCategory.Text = MenuCategoryitem.menu_category_name;
                        btnCategory.DataObject = MenuCategoryitem;
                        btnCategory.Click += new EventHandler(btnCategory_Click);
                        btnCategory.Font = new System.Drawing.Font(DefaultFontControl.FontName, DefaultFontControl.FontSize, FontStyle.Bold);

                        fPnlMainMenu.Controls.Add(btnCategory);
                    }
                }
            }
        }

        protected void btnCategory_Click(object sender, EventArgs e)
        {
            BaseButton btnCategory = sender as BaseButton;
            fPnlMenuItem.Controls.Clear();
            fPnlMainMenu.Controls.Clear();
            if (btnCategory != null)
            {
                MenuCategory MenuCategorySelect = btnCategory.DataObject as MenuCategory;
                this.LoadMenuToContaner(MenuCategorySelect.dining_type_id, MenuCategorySelect.menu_group_id, MenuCategorySelect.menu_category_id);
            }
        }
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            BaseButton btnMenu = sender as BaseButton;

            OrderDTO orderSelect = btnMenu.DataObject as OrderDTO;
            if (orderSelect != null)
            {
                List<OrderDTO> mainMenuList = ServiceProvider.MenuService.LoadMainMenu(orderSelect.menu_id, orderSelect.menu_dining_type_id, orderSelect.menu_group_id, orderSelect.menu_category_id);
                this.BindMenu(mainMenuList, fPnlMenuItem, Theme.MSOffice2010_BLUE);
            }
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
                fPnlMenuItem.Controls.Clear();

                ListViewItem addItem = lisMenuOrder.SelectedItems[0];
                long sales_order_detail_id = Converts.ParseLong(addItem.Name);
                OrderDTO updateItem = this.OrderList.Where(a => a.sales_order_detail_id == sales_order_detail_id).FirstOrDefault();

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
            btnStartTime.Theme = Theme.MSOffice2010_Green;
            btnStartTime.Text = "Re-New";
            btnStartTime.Invalidate();
            timeEating.Stop();
            timeEating.Start();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.CloseScreen();
        }
        #endregion

        private void btnPerson_Click(object sender, EventArgs e)
        {
            using (PopUpPerson form = new PopUpPerson())
            {
                form.openPopupHandler += new PopupBase.OpenPupupHandler(form_openPopupHandler);
                form.closePopupHandler += new PopUpPerson.ClosePopupHandler(form_closePopupHandler);
                DialogResult result = form.ShowDialog();
                this.Activate();

            }
        }

        protected void form_closePopupHandler(object orderHead)
        {
            this.OrderHeads = orderHead as OrderHeadDTO;
            labPersonCount.Text = this.OrderHeads.Person.ToString();
        }

        protected OrderHeadDTO form_openPopupHandler()
        {
            return this.OrderHeads;
        }

        private void timeEating_Tick(object sender, EventArgs e)
        {
            if (this.OrderHeads.IsStartTime)
            {
                if (btnStartTime.Theme == Theme.MSOffice2010_Green)
                {
                    btnStartTime.Theme = Theme.MSOffice2010_RED;

                }
                else
                {
                    btnStartTime.Theme = Theme.MSOffice2010_Green;
                }
                btnStartTime.Invalidate();

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
