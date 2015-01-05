using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.Control;
using POS.BL.Utilities;

namespace POS.IN.CountStock
{
    public partial class AddEditCountStock : BaseAddEditMaster
    {
        #region :: Properties ::
        private ObjectState mode { get; set; }
        private string keyCode { get; set; }
        public AddEditCountStock()
        {
            mode = ObjectState.Add;
            InitializeComponent();
            this.Load += new EventHandler(AddEditEmployee_Load);
        }
        public AddEditCountStock(string Code)
        {
            mode = ObjectState.Edit;
            keyCode = Code;
            InitializeComponent();
            this.Load += new EventHandler(AddEditEmployee_Load);
        }
        #endregion

         #region :: Private Function ::
        private void AddEditEmployee_Load(object sender, EventArgs e)
        {
            //LoadData();
        }
         #endregion

    }
}
