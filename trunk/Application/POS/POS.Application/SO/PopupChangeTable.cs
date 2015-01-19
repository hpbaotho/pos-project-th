using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.Utilities;
using POS.BL.DTO.SO;
using POS.BL.Entities.Entity;
using POS.BL;
using POS.Control;

namespace POS.SO
{
    public partial class PopupChangeTable : Control.PopupBase
    {
        private OrderHeadDTO _OrderHeads;

        public PopupChangeTable()
        {


            InitializeComponent();
            timer1.Enabled = false;
            timer1.Stop();
            base.BindConfigScreen(pnlTableView, ControlCode.POS, null);
            timer1.Enabled = true;
            timer1.Start();
            this.TableClickEvent += new TableClickHandler(PopupChangeTable_TableClickEvent);
        }

        void PopupChangeTable_TableClickEvent(string tableCode)
        {
            this.UpdateTable(tableCode);
        }

        private void UpdateTable(string tableCode)
        {
            if (ServiceProvider.SOTableService.SwitchTable(_OrderHeads, _OrderHeads.TableCode, tableCode))
            {
                _OrderHeads.TableCode = tableCode;
                this.ClosePopup(_OrderHeads);
            }
            else
            {
                this.ShowErrorMessage("Please re-Select Table this table is not available!. ");
            }
        }

        private void PopupChangeTable_Shown(object sender, EventArgs e)
        {
            _OrderHeads = this.popupDataSource as OrderHeadDTO;
            if (_OrderHeads != null)
            {

            }
            else
            {
                this.CloseScreen();
            }
        }

        private void baseButton1_Click(object sender, EventArgs e)
        {
            this.CloseScreen();
        }

        private void timer1_Tick(object sender, EventArgs e)
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

        private void btnTakeAway_Click(object sender, EventArgs e)
        {

            this.UpdateTable(string.Empty);

        }
    }
}
