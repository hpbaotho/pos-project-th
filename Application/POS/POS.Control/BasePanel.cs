using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS.Control
{
    public partial class BasePanel : Panel
    {
        private object dataObj;
        public object DataObject
        {
            get
            {
                return dataObj;
            }
            set { dataObj = value; }
        }
        public BasePanel()
        {
            InitializeComponent();
        }

        public BasePanel(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }
}
