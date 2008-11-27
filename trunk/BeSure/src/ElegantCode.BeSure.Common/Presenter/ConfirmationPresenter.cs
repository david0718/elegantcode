using System.Windows.Forms;
using ElegantCode.BeSure.Common.Util;
using ElegantCode.BeSure.Common.View;
using Microsoft.Office.Interop.Outlook;

namespace ElegantCode.BeSure.Common.Presenter
{
    public class ConfirmationPresenter
    {
        public bool SenderWantsToCancel(IConfirmationView view, MailItem mailItem)
        {
            InitializeDialog(view, mailItem);
            DialogResult result = view.ShowDialog();
            return result == DialogResult.No;
        }

        private void InitializeDialog(IConfirmationView view, _MailItem mailItem)
        {
            view.AccountName = mailItem.SendUsingAccount.DisplayName;
            view.To = AddressSplitter.SplitAddresses(mailItem.To);
            view.CC = AddressSplitter.SplitAddresses(mailItem.CC);
            view.BCC = AddressSplitter.SplitAddresses(mailItem.BCC);
            view.NumberOfAttachments = mailItem.Attachments.Count;
        }
    }
}