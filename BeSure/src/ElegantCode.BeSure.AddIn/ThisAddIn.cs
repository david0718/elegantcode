using System;
using System.Windows.Forms;
using ElegantCode.BeSure.Common.Presenter;
using ElegantCode.BeSure.Common.View;
using Microsoft.Office.Interop.Outlook;
using Exception=System.Exception;

namespace AddIn
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            Application.ItemSend += Application_ItemSend;
        }

        private void Application_ItemSend(object item, ref bool cancel)
        {
            if (!(item is MailItem))
            {
                return;
            }
            cancel = CheckIfUserWantsToCancelEmail(item);
        }

        private bool CheckIfUserWantsToCancelEmail(object item)
        {
            try
            {
                IConfirmationView view = new ConfirmationView();
                var presenter = new ConfirmationPresenter();
                return !presenter.SenderWantsToCancel(view, (MailItem)item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            Startup += ThisAddIn_Startup;
        }

        #endregion
    }
}