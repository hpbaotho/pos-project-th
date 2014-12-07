using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.Utilities;
using Core.Standards.Exceptions;
using Core.Standards.Validations;

namespace POS.Control
{
    public class FormBase : Form
    {

       
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, GeneralMessage.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, GeneralMessage.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void ShowErrorMessage(ValidationException error)
        {
            string template = "Please see error[s] as detail" + Environment.NewLine;

            foreach (ValidationError message in error.Errors)
            {
                template += "  - " + message.ErrorMessage + Environment.NewLine;
            }
            MessageBox.Show(template, GeneralMessage.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        protected void BindConfigScreen(Panel contanner,string screenCode){
        
        }
    }
}
