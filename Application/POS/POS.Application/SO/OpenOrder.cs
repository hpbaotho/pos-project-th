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
namespace POS.SO
{
    public partial class OpenOrder : Control.FormBase
    {
        public OpenOrder()
        {
            InitializeComponent();
            base.BindConfigScreen(pnlNumScreen, ControlCode.OpenOrder, txtCommand);
            this.LoadMenuToContaner();
            lisMenuOrder.Columns.Add("Menu Name",350, HorizontalAlignment.Left);
            lisMenuOrder.Columns.Add("Oty",-2, HorizontalAlignment.Right);
            lisMenuOrder.FullRowSelect = true;
            lisMenuOrder.View = View.Details;
        }

        private void LoadMenuToContaner()
        {
            List<SOMenu> mainMenu = ServiceProvider.MenuService.LoadMainMenu(new SOMenu());
            BindMenu(mainMenu, fPnlMainMenu, Theme.MSOffice2010_RED);
        }

        private void BindMenu(List<SOMenu> mainMenu, FlowLayoutPanel flowPanel, POS.Control.Theme t)
        {
            if (mainMenu != null && mainMenu.Count > 0)
            {
                flowPanel.Controls.Clear();
                foreach (SOMenu Menuitem in mainMenu)
                {
                    BaseButton btnMenu = new BaseButton();
                    btnMenu.Width = 150;
                    btnMenu.Height = 70;
                    btnMenu.Text = Menuitem.menu_name;
                    btnMenu.CommandArg = Menuitem.menu_id.Value.ToString();

                    if (ServiceProvider.MenuService.HaveMinuItem(Menuitem))
                    {
                        btnMenu.Click += new EventHandler(btnMenu_Click);
                        btnMenu.Theme = t;
                    }
                    else
                    {
                        btnMenu.Click += new EventHandler(btnMenuItem_Click);
                        btnMenu.Theme = Theme.MSOffice2010_Green;
                    }
                    btnMenu.Font = new System.Drawing.Font(DefaultFontControl.FontName, DefaultFontControl.FontSize, FontStyle.Bold);


                    flowPanel.Controls.Add(btnMenu);
                }
            }
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            BaseButton btnMenu = sender as BaseButton;
            SOMenu mainMenu = new SOMenu();
            mainMenu.menu_reference_id = Converts.ParseLongNullable(btnMenu.CommandArg);

            List<SOMenu> mainMenuList = ServiceProvider.MenuService.LoadMainMenu(mainMenu);
            BindMenu(mainMenuList, fPnlMenuItem, Theme.MSOffice2010_BLUE);
        }

        protected void btnMenuItem_Click(object sender, EventArgs e)
        {
            BaseButton btnMenu = sender as BaseButton;
            SOMenu mainMenu = new SOMenu();
            mainMenu.menu_id = Converts.ParseLongNullable(btnMenu.CommandArg);
            mainMenu = ServiceProvider.MenuService.FindByKeys(mainMenu, false);
            int menuCount = Converts.ParseInt(txtCommand.Text);
            if (menuCount == 0)
            {
                menuCount = 1;
            }
            ListViewItem item = new ListViewItem(mainMenu.menu_name);
            item.SubItems.Add(menuCount.ToString());

            lisMenuOrder.Items.Add(item);
            txtCommand.Text = string.Empty;
            fPnlMenuItem.Controls.Clear();
        }
    }
}
