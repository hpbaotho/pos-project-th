using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using POS.CustomControls;
using System.Threading;

namespace POS
{/// 
/// Handles a thread (unhandled) exception.
/// 
    internal class ThreadExceptionHandler
    {
        /// 
        /// Handles the thread exception.
        /// 
        public void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                // Exit the program if the user clicks Abort.
                ErrorMessageBox.Show(e.Exception.Message, e.Exception.StackTrace);
            }
            catch
            {
                // Fatal error, terminate program
                try
                {
                    MessageBox.Show("Fatal Error",
                        "Fatal Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
                 // Subscribe to thread (unhandled) exception events
                ThreadExceptionHandler handler =      new ThreadExceptionHandler();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException +=    new ThreadExceptionEventHandler( handler.Application_ThreadException);
                Application.Run(new TestGridControl());
            
           
        }

    }
}
