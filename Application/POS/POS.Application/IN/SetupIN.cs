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
using POS.IN.StockCount;
using POS.IN.IssueMaterial;
using POS.IN.IssueSold;
using POS.IN.ReceiveOrder;
using POS.IN.SetupMaterial;
using POS.IN.SetupMaterialGroup;
using POS.IN.SetupPeriodGroup;
using POS.IN.SetupPeriod;

namespace POS.IN
{
    public partial class SetupIN : POS.Control.FormBase
    {
        List<ListMenuDTO> listMenuDTO = new List<ListMenuDTO>();

        public SetupIN()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            var toolStrip = new ToolStrip();
            toolStrip.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(toolStrip);
            tableLayoutPanel1.SetCellPosition(toolStrip, new TableLayoutPanelCellPosition(0, 0));
            tableLayoutPanel1.SetColumnSpan(toolStrip, 3);

            //---Add list Menu
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.INReceive, MenuName = ProgramName.SetupINReceiveMaterial });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.INReceive, MenuName = ProgramName.SetupINReceiveOrder });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.INIssue, MenuName = ProgramName.SetupINIssueMaterial });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.INIssue, MenuName = ProgramName.SetupINIssueSold });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.INStock, MenuName = ProgramName.SetupINStockCount });
            
            btnManage_Click(btnReceive, null);
            btnReceive.Focus();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Name == "btnReceive")
            {
                listMenu.DataSource = listMenuDTO.Where(item => item.Module == ModuleName.INReceive).Select(item => item.MenuName).ToList();
            }
            else if (btn.Name == "btnIssue")
            {
                listMenu.DataSource = listMenuDTO.Where(item => item.Module == ModuleName.INIssue).Select(item => item.MenuName).ToList();
            }
            else if (btn.Name == "btnStock")
            {
                listMenu.DataSource = listMenuDTO.Where(item => item.Module == ModuleName.INStock).Select(item => item.MenuName).ToList();
            }

            listMenu.ClearSelected();
        }

        private void listMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listMenu = sender as ListBox;

            string selected = listMenu.SelectedItem == null ? null : listMenu.SelectedItem.ToString();

            pnlContent.Controls.Clear();

            switch (selected)
            {
                case ProgramName.SetupINReceiveMaterial: pnlContent.Controls.Add(new ucReceiveMaterial()); break;
                case ProgramName.SetupINReceiveOrder: pnlContent.Controls.Add(new ucReceiveOrder()); break;
                case ProgramName.SetupINIssueMaterial: pnlContent.Controls.Add(new ucIssueMaterial()); break;
                case ProgramName.SetupINIssueSold: pnlContent.Controls.Add(new ucIssueSold()); break;
                case ProgramName.SetupINStockCount: pnlContent.Controls.Add(new ucStockCount()); break;
            }

        }

    }
}
