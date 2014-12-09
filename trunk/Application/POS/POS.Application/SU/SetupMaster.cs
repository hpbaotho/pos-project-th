﻿using System;
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

namespace POS.SU
{
    public partial class SetupMaster : POS.Control.FormBase
    {
        List<ListMenuDTO> listMenuDTO = new List<ListMenuDTO>();

        public SetupMaster()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            var toolStrip = new ToolStrip();
            toolStrip.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(toolStrip);
            tableLayoutPanel1.SetCellPosition(toolStrip, new TableLayoutPanelCellPosition(0, 0));
            tableLayoutPanel1.SetColumnSpan(toolStrip, 3);

            //---Add list Menu
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.SetupEmployee });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.SetupRole });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.AssignEmployeeRole });
            listMenuDTO.Add(new ListMenuDTO() { Module = ModuleName.Setting, MenuName = ProgramName.SystemConfiguration });

            btnManage_Click(btnSetting, null);
            btnSetting.Focus();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Name == "btnSetting")
            {
                listMenu.DataSource = listMenuDTO.Where(item => item.Module == ModuleName.Setting).Select(item => item.MenuName).ToList();
            }
            else if (btn.Name == "btnInventory")
            {
                listMenu.DataSource = listMenuDTO.Where(item => item.Module == ModuleName.Inventory).Select(item => item.MenuName).ToList();
            }

            listMenu.ClearSelected();
            toolStripGridview.Visible = false;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listMenu = sender as ListBox;
            gridContent.DataSource = null;
            gridContent.AutoGenerateColumns = true;
            gridContent.DataMember = "Table";
            toolStripGridview.Visible = true;

            string selected = listMenu.SelectedItem == null ? null : listMenu.SelectedItem.ToString();

            if (selected == ProgramName.SetupEmployee)
            {
                gridContent.DataSource = ServiceProvider.EmployeeService.FindAllDataSet(false);
            }
            else if (selected == ProgramName.SetupRole)
            {
                gridContent.DataSource = ServiceProvider.RoleService.FindAllDataSet(false);
            }
            else if (selected == ProgramName.SystemConfiguration)
            {
                gridContent.DataSource = ServiceProvider.SystemConfigurationService.FindAllDataSet(false);
            }
            else
            {
                toolStripGridview.Visible = false;
                gridContent.DataSource = null;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
