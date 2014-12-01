using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS.CustomControls.GridView
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }
        public EditForm(DataGridViewRow row)
        {
            InitializeComponent();
            this.tbLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.ValueType == typeof(string))
                {

                    tbLayout.Controls.Add(new TextBox() { Text = cell.Value.ToString() }, 0, cell.ColumnIndex);

                }
         

            }
            //tbLayout.Controls = tbLaoutControl;


        }
        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        private void tbLayout_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
