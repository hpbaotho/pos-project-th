using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.DTO.SU;
using POS.BL.Utilities;
using POS.BL.Service.SU;
using POS.BL;
using Core.Standards.Converters;
using POS.BL.Entities.Entity;
using POS.IN.ReceiveMaterial;
using POS.IN.CountStock;
using POS.IN.IssueMaterialSold;
using POS.IN.IssueMaterialWareHouseOther;
using POS.IN.IssueMaterialWaste;
using POS.Control;
using POS.KC.KitchenOrderList;

namespace POS.KC
{
    public partial class KCCommand : POS.Control.FormBase
    {
        List<ListMenuDTO> listMenuDTO = new List<ListMenuDTO>();
        Dictionary<ListMenuDTO, BaseUserControl> AssociationControl = new Dictionary<ListMenuDTO, BaseUserControl>();

        private BaseUserControl OrderListPage { get { return new ucKitchenOrderList();}}

        public KCCommand()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            var toolStrip = new ToolStrip();
            toolStrip.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(toolStrip);
            tableLayoutPanel1.SetCellPosition(toolStrip, new TableLayoutPanelCellPosition(0, 0));
            tableLayoutPanel1.SetColumnSpan(toolStrip, 3);


            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Kitchen, MenuName = ProgramName.KitchenOrderList  });
            //AddMenu(ModuleName.Kitchen, ProgramName.SetupINCountStock, OrderListPage);


            listMenu.DataSource = listMenuDTO.Where(item => item.Module == ModuleName.Kitchen ).Select(item => item.MenuName).ToList();
        }


        private void AddMenu(string Module, string ProgrameName, BaseUserControl AssociatedControl)
        {
            ListMenuDTO newItem = new ListMenuDTO() { Module = Module , MenuName = ProgrameName };
            AssociationControl.Add(newItem, AssociatedControl);
        }

        private void listMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listMenu = sender as ListBox;

            string selected = listMenu.SelectedItem == null ? null : listMenu.SelectedItem.ToString();

            pnlContent.Controls.Clear();

            if (selected == ProgramName.KitchenOrderList)
            {
                pnlContent.Controls.Add(new ucKitchenOrderList());
            }

        }

    }
}
