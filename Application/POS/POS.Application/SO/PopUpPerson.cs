using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.DTO.SO;

namespace POS.SO
{
    public partial class PopUpPerson : Form
    {
        OrderHeadDTO OrderHeads;

        public delegate void ClosePopupHandler(OrderHeadDTO orderHead);
        public event ClosePopupHandler closePopupHandler;

        public delegate OrderHeadDTO OpenPupupHandler();
        public event OpenPupupHandler openPopupHandler;

        public PopUpPerson()
        {
            InitializeComponent();
            this.OrderHeads = new OrderHeadDTO();

        }
        protected override void OnShown(EventArgs e)
        {
            if (openPopupHandler != null)
            {
                this.OrderHeads = openPopupHandler();

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
            if (closePopupHandler != null)
            {
                closePopupHandler(this.OrderHeads);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnDelPeson_Click(object sender, EventArgs e)
        {
            if (this.OrderHeads != null)
            {

                this.OrderHeads.Person -= 1;

                btnPerson.Text = string.Format("+ ลูกค้า ({0})", this.OrderHeads.Person);
            }
        }

       
    }
}
