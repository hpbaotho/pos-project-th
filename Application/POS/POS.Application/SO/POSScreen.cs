﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.Utilities;
using POS.BL.Entities.Entity;
using POS.BL;
using POS.Control;
using Core.Standards.Validations;

namespace POS.SO
{
    public partial class POSScreen : Control.FormBase
    {
        public POSScreen()
        {
            InitializeComponent();
            base.BindConfigScreen(pnlTableView, ControlCode.POS, null);
            this.TableClickEvent += new TableClickHandler(POSScreen_TableClickEvent);

        }
        private void POSScreen_Shown(object sender, EventArgs e)
        {
            WorkPeriod activeWorkPeriod = ServiceProvider.WorkPeriodService.findActiveWorkPeriod();
            if (activeWorkPeriod != null)
            {
                timerTable.Start();
            }
            else
            {
                this.ShowErrorMessage("Please Open Work Perion!");
                base.CloseScreen();
            }
        }
        protected void POSScreen_TableClickEvent(string tableCode)
        {
            SOTable selectTable = ServiceProvider.SOTableService.GetTaleByCode(tableCode);
            if (selectTable != null && selectTable.active)
            {
                ServiceProvider.SOTableService.BookTable(tableCode);
                base.OpernNewScreen<OpenOrder>(tableCode);
                SaleOrderHeader orderHead = ServiceProvider.SaleOrderHeaderService.GetOrdrtHeadByTable(tableCode);
                if (orderHead == null) {
                    ServiceProvider.SOTableService.CancelBookTable(tableCode);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.CloseScreen();
        }

        private void timerTable_Tick(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Control item in pnlTableView.Controls)
            {
                if (item.GetType() == typeof(Control.BasePanel))
                {
                    BasePanel bp = item as BasePanel;
                    ScreenConfig scConfig = bp.DataObject as ScreenConfig;
                    if (scConfig.control_type == ControlType.Table)
                    {
                        string TableCode = scConfig.control_command;
                        SOTable selectTable = ServiceProvider.SOTableService.GetTaleByCode(TableCode);
                        if (selectTable != null)
                        {
                            item.Visible = selectTable.active;
                            if (!selectTable.IsAvailable)
                            {
                                bp.BackColor = Color.Green;
                            }
                            else
                            {
                                bp.BackColor = Color.Transparent;
                            }
                        }
                        else
                        {
                            item.Visible = false;
                        }
                    }
                }
            }
        }


    }
}
