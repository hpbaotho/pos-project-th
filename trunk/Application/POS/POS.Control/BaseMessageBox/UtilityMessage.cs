using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS.Control.BaseMessageBox
{
    public static class UtilityMessage
    {
        public static void Alert(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static bool Confirm(string text, string caption)
        {
            DialogResult result = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
        public static void Warning(string text, string caption)
        {
            //DialogResult result = 
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //return result == DialogResult.Yes;
        }
        public static void ErrorMessage(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
