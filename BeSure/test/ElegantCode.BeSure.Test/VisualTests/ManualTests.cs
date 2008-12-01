using System.Collections.Generic;
using System.Windows.Forms;
using ElegantCode.BeSure.Common.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElegantCode.BeSure.Test.VisualTests
{
    [TestClass]
    public class ManualTests
    {
        [TestMethod]
        public void ShowTheForm()
        {
            var confirmationDialog = new ConfirmationView();

            confirmationDialog.AccountName = "This is the Account Name";


            confirmationDialog.To = new List<string>
                                        {
                                            "Homer",
                                            "Bart"
                                        };

            confirmationDialog.CC = new List<string>
                                        {
                                            "Maggie",
                                            "Lisa"
                                        };

            confirmationDialog.BCC = new List<string>
                                         {
                                             "Marge1",
                                             "Marge2",
                                             "Marge3",
                                             "Marge4",
                                             "Marge5",
                                             "Marge6",
                                             "Marge7",
                                             "Marge8",
                                             "Marge9"
                                         };

            confirmationDialog.Subject = "This is the subject";
            confirmationDialog.Sender = "me@me.com";
            confirmationDialog.NumberOfAttachments = 5;

            DialogResult result = confirmationDialog.ShowDialog();
        }
    }
}