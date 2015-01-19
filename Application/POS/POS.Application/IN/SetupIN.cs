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
using POS.IN.ReceiveOrder;

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
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.SetupINIssueMaterialWarehouse });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.SetupINIssueMaterialSold });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.SetupINIssueMaterialWaste });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.SetupINCountStock });

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
            else if (selected == ProgramName.SetupINIssueMaterialWarehouse)
            {
                pnlContent.Controls.Add(new ucIssueMaterialWareHouseOther());
            }
            else if (selected == ProgramName.SetupINIssueMaterialSold)
            {
                pnlContent.Controls.Add(new ucIssueMaterialSold());
            }
            else if (selected == ProgramName.SetupINIssueMaterialWaste)
            {
                pnlContent.Controls.Add(new ucIssueMaterialWaste());
            }    
            else if (selected == ProgramName.SetupINCountStock)
            {
                pnlContent.Controls.Add(new ucCountStock());
            }

        }

    }
}
