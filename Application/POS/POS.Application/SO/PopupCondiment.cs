using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.Control;
using POS.BL.DTO.SO;

namespace POS.SO
{
    public partial class PopupCondiment : PopupBase
    {
        OrderDTO parentMenu = null;
        public PopupCondiment()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            if (this.PageObjrct != null)
            {
                this.parentMenu = this.PageObjrct as OrderDTO;
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            OrderDTO openCondiment = new OrderDTO();
            openCondiment.menu_name = txtMenuName.Text.Trim();
            openCondiment.order_amount = 1;
            openCondiment.menu_price = Core.Standards.Converters.Converts.ParseDecimal(txtPrice.Text);
            openCondiment.ref_menu_dining_type_id = parentMenu.menu_dining_type_id;
            openCondiment.parent_sales_order_detail_id = parentMenu.sales_order_detail_id;
            openCondiment.IsCondiment = true;
            this.CloseScreen(openCondiment);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.CloseScreen();
        }
    }
}
