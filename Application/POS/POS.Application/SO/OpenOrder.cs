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
using Core.Standards.Validations;
namespace POS.SO
{
    public partial class OpenOrder : Control.FormBase
    {
        #region :: Property ::
        int defaultBtnW = 120;
        int defaultBtnH = 60;
        Font defaultBtnFont;
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

        #endregion


        public OpenOrder()
        {
            InitializeComponent();
            this.defaultBtnFont = new System.Drawing.Font(DefaultFontControl.FontName, DefaultFontControl.FontSizeM, FontStyle.Bold);
            base.BindConfigScreen(pnlNumScreen, ControlCode.OpenOrder, txtCommand);
            lisMenuOrder.Columns.Add("Chk", 50, HorizontalAlignment.Left);
            lisMenuOrder.Columns.Add("Menu Name", 200, HorizontalAlignment.Left);
            lisMenuOrder.Columns.Add("Oty", 50, HorizontalAlignment.Right);
            lisMenuOrder.Columns.Add("Price", -2, HorizontalAlignment.Right);

            lisMenuOrder.View = View.Details;
            this.LoadDiningType();

        }
        private void OpenOrder_Shown(object sender, EventArgs e)
        {
            string tableCode = string.Empty;
            if (this.popupDataSource.GetType() == typeof(string))
            {
                tableCode = this.popupDataSource.ToString();
                if (!string.IsNullOrEmpty(tableCode))
                {
                    this.OrderHeads = ServiceProvider.SaleOrderHeaderService.GetOrderByTable(tableCode);
                }
            }
            else if (this.popupDataSource.GetType() == typeof(SaleOrderHeader))
            {
                SaleOrderHeader takeAwayOrder = this.popupDataSource as SaleOrderHeader;
                this.OrderHeads = ServiceProvider.SaleOrderHeaderService.GetOrderOrderHeader(takeAwayOrder);
            }
            //Update Oder information
            this.CheckStartEatingTime();
            this.OrderHeads.TableCode = tableCode;
            labPersonCount.Text = this.OrderHeads.Person.ToString();

            this.BindListOrder();
            this.UpdateOrderHeadToScreen();

            //Auto Click Button menu
            foreach (System.Windows.Forms.Control item in fPnlDiningType.Controls)
            {
                if (item.GetType() == typeof(BaseButton))
                {
                    BaseButton btn = item as BaseButton;
                    btn.PerformClick();
                    break;
                }
            }

            foreach (System.Windows.Forms.Control item in fPnlMainMenu.Controls)
            {
                if (item.GetType() == typeof(BaseButton))
                {
                    BaseButton btn = item as BaseButton;
                    btn.PerformClick();
                    break;
                }
            }


        }
        #region :: Costom Function ::



        private long GetOrderMenuId()
        {
            long orderDetailId = -1;
            long minId = this.OrderHeads.OrderList.Count > 0 ? this.OrderHeads.OrderList.Min(a => a.sales_order_detail_id).Value : 0;
            if (minId > 0)
            {
                orderDetailId = -1;
            }
            else
            {
                orderDetailId = minId - 1;
            }
            return orderDetailId;
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
                    btnDining.Width = this.defaultBtnW;
                    btnDining.Height = this.defaultBtnH;
                    btnDining.Text = Diningitem.dining_type_name;
                    btnDining.CommandArg = Diningitem.dining_type_id.Value.ToString();
                    btnDining.DataObject = Diningitem;
                    btnDining.Theme = Theme.MSOffice2010_BLUE;
                    btnDining.Click += new EventHandler(btnDiningi_Click);
                    btnDining.Font = this.defaultBtnFont;
                    fPnlDiningType.Controls.Add(btnDining);
                }

            }
        }
        private void LoadMenuGroupByDiningType(DiningType diningSelect)
        {
            fPnlMainMenu.Controls.Clear();

            List<MenuGroup> menuGroup = ServiceProvider.MenuGroupService.FindByDiningType(diningSelect.dining_type_id.Value);
            if (menuGroup != null && menuGroup.Count > 0)
            {


                foreach (MenuGroup MenuGroupitem in menuGroup)
                {
                    BaseButton btnMenuGroup = new BaseButton();
                    btnMenuGroup.Width = this.defaultBtnW;
                    btnMenuGroup.Height = this.defaultBtnH;
                    btnMenuGroup.Theme = Theme.MSOffice2010_Violet;
                    btnMenuGroup.Text = MenuGroupitem.menu_group_name;
                    btnMenuGroup.DataObject = MenuGroupitem;
                    btnMenuGroup.Click += new EventHandler(btnMenuGroup_Click);
                    btnMenuGroup.Font = this.defaultBtnFont;

                    fPnlMainMenu.Controls.Add(btnMenuGroup);
                }
            }
        }

        private void LoadMenuToContaner(int diningTypeId, long? menuGroupId, long? menuCategoryId)
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
                    btnMenu.Width = this.defaultBtnW;
                    btnMenu.Height = this.defaultBtnH;
                    btnMenu.Text = Menuitem.menu_name;
                    btnMenu.CommandArg = Menuitem.menu_id.ToString();
                    btnMenu.DataObject = Menuitem;
                    if (ServiceProvider.MenuService.HaveMinuItem(Menuitem.menu_id, Menuitem.dining_type_id, Menuitem.menu_group_id, Menuitem.menu_category_id))
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
                    btnMenu.Font = this.defaultBtnFont;


                    flowPanel.Controls.Add(btnMenu);
                }
            }
        }
        private void BindListOrder()
        {
            lisMenuOrder.Items.Clear();
            lisMenuOrder.Focus();

            foreach (OrderDTO Orderitem in this.OrderHeads.OrderList.Where(o => o.OrderState != ObjectState.Delete && !o.condiment_of_order_detail_id.HasValue).OrderByDescending(c => c.ChkNo))
            {
                ListViewItem item = new ListViewItem(Orderitem.ChkNo.ToString());
                if (Orderitem.is_print)
                    item.ForeColor = Color.Blue;
                item.SubItems.Add(Orderitem.menu_name);
                item.SubItems.Add(Orderitem.order_amount.ToString());
                item.SubItems.Add(Orderitem.TotalAmount.ToString());
                item.Name = Orderitem.sales_order_detail_id.ToString();
                item.Selected = Orderitem.Selected;
                lisMenuOrder.Items.Add(item);

                foreach (OrderDTO Condimentitem in this.OrderHeads.OrderList.Where(o => o.OrderState != ObjectState.Delete && o.condiment_of_order_detail_id == Orderitem.sales_order_detail_id))
                {
                    ListViewItem CondimentListitem = new ListViewItem(Condimentitem.ChkNo.ToString());
                    if (Orderitem.is_print)
                        CondimentListitem.ForeColor = Color.Blue;
                    CondimentListitem.SubItems.Add(" - " + Condimentitem.menu_name);
                    CondimentListitem.SubItems.Add(Condimentitem.order_amount.ToString());
                    CondimentListitem.SubItems.Add(Condimentitem.TotalAmount.ToString());
                    CondimentListitem.Name = Condimentitem.sales_order_detail_id.ToString();
                    CondimentListitem.Selected = Condimentitem.Selected;
                    lisMenuOrder.Items.Add(CondimentListitem);


                }



            }


            labTotalPrice.Text = string.Format(Format.DecimalNumberFormat2DZero, this.OrderHeads.OrderList.Sum(a => a.TotalAmount));
        }

        private void AddMenu()
        {

            if (lisMenuOrder.SelectedItems.Count > 0)
            {
                this.OrderHeads.OrderList.ForEach(a => a.Selected = false);
                ListViewItem addItem = lisMenuOrder.SelectedItems[0];
                long sales_order_detail_id = Converts.ParseLong(addItem.Name);
                OrderDTO updateItem = this.OrderHeads.OrderList.Where(a => a.sales_order_detail_id == sales_order_detail_id).FirstOrDefault();
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
                OrderDTO updateItem = this.OrderHeads.OrderList.Where(a => a.sales_order_detail_id == sales_order_detail_id).FirstOrDefault();
                updateItem.order_amount = updateItem.order_amount - 1;

                if (updateItem.order_amount <= 0)
                {
                    if (updateItem != null && updateItem.OrderState == ObjectState.Add)
                    {
                        this.OrderHeads.OrderList.Remove(updateItem);

                    }
                    else if (updateItem != null && updateItem.OrderState == ObjectState.Edit)
                    {
                        updateItem.OrderState = ObjectState.Delete;
                    }
                    fPnlMenuItem.Controls.Clear();
                }
                else
                {
                    updateItem.Selected = true;
                }
                this.BindListOrder();
            }
        }

        #endregion

        #region  :: Event Button ::
        protected void btnDiningi_Click(object sender, EventArgs e)
        {
            BaseButton btnDining = sender as BaseButton;


            if (btnDining != null)
            {
                DiningType diningSelect = btnDining.DataObject as DiningType;
                this.LoadMenuGroupByDiningType(diningSelect);
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
                        btnCategory.Theme = Theme.MSOffice2010_Yellow;
                        btnCategory.Width = this.defaultBtnW;
                        btnCategory.Height = this.defaultBtnH;
                        btnCategory.Text = MenuCategoryitem.menu_category_name;
                        btnCategory.DataObject = MenuCategoryitem;
                        btnCategory.Click += new EventHandler(btnCategory_Click);
                        btnCategory.Font = this.defaultBtnFont;

                        fPnlMainMenu.Controls.Add(btnCategory);
                    }
                }
            }
        }
        protected void btnCategory_Click(object sender, EventArgs e)
        {
            BaseButton btnCategory = sender as BaseButton;

            if (btnCategory != null)
            {

                MenuCategory MenuCategorySelect = btnCategory.DataObject as MenuCategory;
                this.LoadMenuToContaner(MenuCategorySelect.dining_type_id, MenuCategorySelect.menu_group_id, MenuCategorySelect.menu_category_id);
                this.LoadMenuGroupByDiningType(new DiningType() { dining_type_id = MenuCategorySelect.dining_type_id });
            }


        }
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            BaseButton btnMenu = sender as BaseButton;

            OrderDTO orderSelect = btnMenu.DataObject as OrderDTO;
            if (orderSelect != null)
            {
                List<OrderDTO> mainMenuList = ServiceProvider.MenuService.LoadMainMenu(orderSelect.menu_id, orderSelect.dining_type_id, orderSelect.menu_group_id, orderSelect.menu_category_id);
                this.BindMenu(mainMenuList, fPnlMenuItem, Theme.MSOffice2010_BLUE);
            }
        }
        protected void btnMenuItem_Click(object sender, EventArgs e)
        {
            if (this.OrderHeads.OrderList == null)
            {
                this.OrderHeads.OrderList = new List<OrderDTO>();
            }

            BaseButton btnMenu = sender as BaseButton;
            OrderDTO MenuItem = new OrderDTO();
            MenuItem = btnMenu.DataObject as OrderDTO;


            int menuCount = Converts.ParseInt(txtCommand.Text);
            if (menuCount == 0)
            {
                menuCount = 1;
            }


            long orderDetailId = this.GetOrderMenuId();



            OrderDTO OrderItem = new OrderDTO();
            OrderItem.sales_order_detail_id = orderDetailId;
            OrderItem.order_amount = menuCount;
            OrderItem.order_unit_price = MenuItem.order_unit_price;
            OrderItem.menu_id = MenuItem.menu_id;
            OrderItem.menu_dining_type_id = MenuItem.menu_dining_type_id;
            OrderItem.menu_name = MenuItem.menu_name;
            OrderItem.ChkNo = ServiceProvider.OrderCheckService.GetCheckNo();
            // Chekc Is Inver item?
            if (MenuItem.isInventoryItem)
            {
                OrderDTO ItemInven = this.OrderHeads.OrderList.Where(i => i.menu_id == MenuItem.menu_id).FirstOrDefault();
                if (ItemInven != null)
                {
                    ItemInven.order_amount += menuCount;
                }
                else
                {
                    this.OrderHeads.OrderList.Add(OrderItem);
                }

            }
            else
            {
                this.OrderHeads.OrderList.Add(OrderItem);
            }
            this.BindListOrder();
            txtCommand.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.AddMenu();

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteMenu();

        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            object orderHead = this.OpenPopup<PopUpPerson>(this.OrderHeads);

            this.OrderHeads = orderHead as OrderHeadDTO;
            labPersonCount.Text = this.OrderHeads.Person.ToString();

        }
        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            object orderHead = this.OpenPopup<PopupChangeTable>(this.OrderHeads);
            this.OrderHeads = orderHead as OrderHeadDTO;
            this.UpdateOrderHeadToScreen();
        }
        protected void btnCondiment_Click(object sender, EventArgs e)
        {
            fPnlMenuItem.Controls.Clear();

        }
        protected void btnOpenCondiment_Click(object sender, EventArgs e)
        {
            fPnlMenuItem.Controls.Clear();
            BaseButton btnCondiment = sender as BaseButton;
            object returnObj = base.OpenPopup<PopupCondiment>(btnCondiment.DataObject);

            if (returnObj != null)
            {
                OrderDTO menuCondiment = returnObj as OrderDTO;
                menuCondiment.ChkNo = ServiceProvider.OrderCheckService.GetCheckNo();
                OrderDTO condimentResult = this.OrderHeads.OrderList.Find(a => a.sales_order_detail_id == menuCondiment.condiment_of_order_detail_id);
                if (condimentResult != null)
                {
                    this.OrderHeads.OrderList.ForEach(s => s.Selected = false);
                    condimentResult.Selected = true;

                    long orderDetailId = this.GetOrderMenuId();
                    menuCondiment.sales_order_detail_id = orderDetailId;
                    this.OrderHeads.OrderList.Add(menuCondiment);
                    this.BindListOrder();

                }

            }

        }

        private void btnStartTime_Click(object sender, EventArgs e)
        {
            this.OrderHeads.IsStartTime = true;
            this.CheckStartEatingTime();
        }

        private void CheckStartEatingTime()
        {
            if (this.OrderHeads.IsStartTime)
            {
                btnStartTime.Theme = Theme.MSOffice2010_Green;
                btnStartTime.Text = "Re-New";
                btnStartTime.Invalidate();
                timeEating.Stop();
                timeEating.Start();
            }
            else
            {
                timeEating.Stop();
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            foreach (OrderDTO Orderitem in this.OrderHeads.OrderList.Where(o => o.OrderState != ObjectState.Delete))
            {
                Orderitem.is_print = true;
            }
            ServiceProvider.SaleOrderHeaderService.SendOrderToKitchen(this.OrderHeads);
            this.CloseScreen();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.CloseScreen();
        }
        private void btnCencelBill_Click(object sender, EventArgs e)
        {
            if (base.ShowConfirmMessage("Are you sure to Cancel?", "Cancel Bill"))
            {

                ServiceProvider.SaleOrderHeaderService.CancleOrder(this.OrderHeads);
                this.CloseScreen();
            }
        }
        #endregion

        private void lisMenuOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisMenuOrder.SelectedItems.Count > 0)
            {

                fPnlMenuItem.Controls.Clear();

                ListViewItem addItem = lisMenuOrder.SelectedItems[0];
                long sales_order_detail_id = Converts.ParseLong(addItem.Name);
                OrderDTO updateItem = this.OrderHeads.OrderList.Where(a => a.sales_order_detail_id == sales_order_detail_id && !a.condiment_of_order_detail_id.HasValue).FirstOrDefault();
                if (updateItem != null && !updateItem.is_print)
                {
                    this.OrderHeads.OrderList.ForEach(s => s.Selected = false);
                    updateItem.Selected = true;
                    if (!updateItem.IsCondiment)
                    {
                        List<OrderDTO> CondimetMenu = ServiceProvider.MenuService.LoadCondiMentMenu(updateItem.menu_dining_type_id);
                        if (CondimetMenu != null)
                        {

                            foreach (OrderDTO Condimentitem in CondimetMenu)
                            {
                                Condimentitem.IsCondiment = true;
                                Condimentitem.sales_order_detail_id = sales_order_detail_id;
                                BaseButton btnCondiment = new BaseButton();
                                btnCondiment.Theme = Theme.MSOffice2010_Yellow;
                                btnCondiment.Width = this.defaultBtnW;
                                btnCondiment.Height = this.defaultBtnH;
                                btnCondiment.Text = Condimentitem.menu_name;

                                if (Condimentitem.menu_id.HasValue)
                                {
                                    btnCondiment.Click += new EventHandler(btnCondiment_Click);
                                }
                                else
                                {
                                    Condimentitem.menu_dining_type_id = updateItem.menu_dining_type_id;
                                    btnCondiment.Click += new EventHandler(btnOpenCondiment_Click);
                                }
                                btnCondiment.DataObject = Condimentitem;
                                btnCondiment.Font = this.defaultBtnFont;

                                fPnlMenuItem.Controls.Add(btnCondiment);
                            }
                        }
                    }
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                    btnAdd.Theme = Theme.MSOffice2010_Green;
                    btnDelete.Theme = Theme.MSOffice2010_RED;
                }
                else if (updateItem != null)
                {
                    BaseButton btnCancleMenu = new BaseButton();
                    btnCancleMenu.Theme = Theme.MSOffice2010_RED;
                    btnCancleMenu.Width = this.defaultBtnW;
                    btnCancleMenu.Height = this.defaultBtnH;
                    btnCancleMenu.Text = "Cancle Menu";
                    btnCancleMenu.DataObject = updateItem;
                    btnCancleMenu.Font = this.defaultBtnFont;
                    btnCancleMenu.Click += new EventHandler(btnCancleMenu_Click);
                    fPnlMenuItem.Controls.Add(btnCancleMenu);
                }



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

        void btnCancleMenu_Click(object sender, EventArgs e)
        {
            BaseButton btn = sender as BaseButton;
            if (btn.DataObject != null)
            {
                OrderDTO updateItem = btn.DataObject as OrderDTO;
                updateItem = this.OrderHeads.OrderList.Where(a => a.sales_order_detail_id == updateItem.sales_order_detail_id).FirstOrDefault();
                if (updateItem != null && updateItem.OrderState != ObjectState.Add)
                {
                    updateItem.is_cancel = true;
                    updateItem.OrderState = ObjectState.Edit;
                    this.OrderHeads = ServiceProvider.SaleOrderHeaderService.SendOrderToKitchen(this.OrderHeads);

                }
                else
                {
                    this.OrderHeads.OrderList.Remove(updateItem);
                }

                this.BindListOrder();
            }
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



        private void UpdateOrderHeadToScreen()
        {
            lblTableCode.Text = this.OrderHeads.TableCode;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            SaleOrderHeader orderHear = new SaleOrderHeader();
            orderHear.sales_order_head_id = this.OrderHeads.sales_order_head_id;

            orderHear = ServiceProvider.SaleOrderHeaderService.FindByKeys(orderHear, true);
            if (orderHear != null)
            {
                orderHear.is_payment_procress = true;
                ServiceProvider.SOTableService.CancelBookTable(this.OrderHeads.TableCode);
                ServiceProvider.SaleOrderHeaderService.Update(orderHear, ValidationRuleset.Update);
            }
            this.CloseScreen();
        }











    }

}
