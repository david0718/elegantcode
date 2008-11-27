using System.Collections.Generic;
using System.Windows.Forms;

namespace ElegantCode.BeSure.Common.View
{
    public interface IConfirmationView
    {
        string AccountName { set; }

        List<string> To { set; }
        List<string> CC { set; }
        List<string> BCC { set; }
        int NumberOfAttachments { set; }

        DialogResult ShowDialog();
    }
}