using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.DTO.SO;
using POS.Control;

namespace POS.SO
{
    public partial class PopUpPerson : PopupBase
    {
        OrderHeadDTO OrderHeads;

        public PopUpPerson()
        {
            InitializeComponent();
            this.OrderHeads = new OrderHeadDTO();

        }
        protected override void OnShown(EventArgs e)
        {
            if (this.popupDataSource != null)
            {
                this.OrderHeads = this.popupDataSource as OrderHeadDTO;

                if (this.OrderHeads != null)
                {
                    btnPerson.Text = string.Format("+ ลูกค้า ({0})", this.OrderHeads.Person);
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }

            }
            base.OnShown(e);
        }
        private void btnPerson_Click(object sender, EventArgs e)
        {
            if (this.OrderHeads != null)
            {

                this.OrderHeads.Person += 1;

                btnPerson.Text = string.Format("+ ลูกค้า ({0})", this.OrderHeads.Person);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.ClosePopup(this.OrderHeads);
        }
        private void btnDelPeson_Click(object sender, EventArgs e)
        {
            if (this.OrderHeads != null)
            {

                this.OrderHeads.Person -= 1;
                if (this.OrderHeads.Person < 1) {
                    this.OrderHeads.Person = 1;
                }
                btnPerson.Text = string.Format("+ ลูกค้า ({0})", this.OrderHeads.Person);
            }
        }

       
    }
}
