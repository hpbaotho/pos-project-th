using System;
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
            base.BindConfigScreen(pnlTableView, ControlCode.POS, null, true);
            this.TableClickEvent += new TableClickHandler(POSScreen_TableClickEvent);
            this.LoadTakeOrdermenu();
        }
        private void POSScreen_Shown(object sender, EventArgs e)
        {
            this.ReLoadScreen();
        }

        #region :: Event Button ::

        protected void POSScreen_TableClickEvent(string tableCode)
        {
            SOTable selectTable = ServiceProvider.SOTableService.GetTaleByCode(tableCode);
            if (selectTable != null && selectTable.active)
            {
                ServiceProvider.SOTableService.BookTable(tableCode);
                base.OpernNewScreen<OpenOrder>(tableCode);
                SaleOrderHeader orderHead = ServiceProvider.SaleOrderHeaderService.GetOrdrtHeadByTable(tableCode);
                if (orderHead == null)
                {
                    ServiceProvider.SOTableService.CancelBookTable(tableCode);
                }
            }
            this.ReLoadScreen();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.CloseScreen();
        }
        private void btnTakeaway_Click(object sender, EventArgs e)
        {
            SaleOrderHeader header = new SaleOrderHeader();
            BaseButton btn = sender as BaseButton;
            if (btn.DataObject != null)
            {
                header = btn.DataObject as SaleOrderHeader;
            }
            base.OpernNewScreen<OpenOrder>(header);
            this.ReLoadScreen();
        }

        #endregion

        #region :: Timer Tick ::
        private void timerTakeAway_Tick(object sender, EventArgs e)
        {
            this.LoadTakeOrdermenu();
        }
        private void timerTable_Tick(object sender, EventArgs e)
        {
            this.LoadTableActive();
        }
        #endregion
       
        private void LoadTakeOrdermenu()
        {
            List<SaleOrderHeader> listTakeAway = ServiceProvider.SaleOrderHeaderService.FindTakeAwayOrder();
            pnlTakeAway.Controls.Clear();
            if (listTakeAway != null)
            {
                foreach (SaleOrderHeader item in listTakeAway)
                {
                    TimeSpan dateDiff = (DateTime.Now - item.take_order_date);

                    BaseButton btn = new BaseButton();
                    btn.Width = 291;
                    btn.Height = 63;
                    btn.Font = new Font(FontFamily.GenericSansSerif, 18);
                    btn.Text = string.Format("({0}):{1}", item.take_order_by, dateDiff.ToString(@"hh\:mm\:ss"));
                    btn.DataObject = item;
                    btn.Click += new EventHandler(btnTakeaway_Click);
                    btn.Theme = Theme.MSOffice2010_Violet;
                    pnlTakeAway.Controls.Add(btn);
                }
            }
        }
        private void LoadTableActive()
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
        private void ReLoadScreen()
        {
            timerTable.Stop();
            timerTakeAway.Stop();

            WorkPeriod activeWorkPeriod = ServiceProvider.WorkPeriodService.findActiveWorkPeriod();
            if (activeWorkPeriod != null)
            {
                timerTable.Start();
                timerTakeAway.Start();


                this.LoadTableActive();
                this.LoadTakeOrdermenu();
            }
            else
            {
                this.ShowErrorMessage("Please Open Work Perion!");
                base.CloseScreen();
            }

        }

    }
}
