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
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.SetupINReceiveMaterial });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.SetupINReceiveOrder });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.SetupINIssueMaterial });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.SetupINIssueSold });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.SetupINStockCount });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.SetupINMaterialGroup });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.SetupINMaterial });

            listMenu.DataSource = listMenuDTO.Where(item => item.Module == ModuleName.Setting).Select(item => item.MenuName).ToList();
        }

        private void listMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listMenu = sender as ListBox;

            string selected = listMenu.SelectedItem == null ? null : listMenu.SelectedItem.ToString();

            pnlContent.Controls.Clear();

            if (selected == ProgramName.SetupINReceiveMaterial)
            {
                pnlContent.Controls.Add(new ucReceiveMaterial());
            }
            else if (selected == ProgramName.SetupINReceiveOrder)
            {
                pnlContent.Controls.Add(new ucReceiveOrder());
            }
            else if (selected == ProgramName.SetupINIssueMaterial)
            {
                pnlContent.Controls.Add(new ucIssueMaterial());
            }
            else if (selected == ProgramName.SetupINIssueSold)
            {
                pnlContent.Controls.Add(new ucIssueSold());
            }
            else if (selected == ProgramName.SetupINStockCount)
            {
                pnlContent.Controls.Add(new ucStockCount());
            }
            else if (selected == ProgramName.SetupINMaterialGroup)
            {
                pnlContent.Controls.Add(new ucMaterialGroup());
            }
            else if (selected == ProgramName.SetupINMaterial)
            {
                pnlContent.Controls.Add(new ucSetupMaterial());
            }
        }

    }
}
