using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ElegantCode.BeSure.Common.View
{
    public partial class ConfirmationView : Form, IConfirmationView
    {
        public ConfirmationView()
        {
            InitializeComponent();
        }

        #region IConfirmationView Members

        public string AccountName
        {
            set { _tbAccountName.Text = value; }
        }

        public string Subject
        {
            set { this._tbSubject.Text = value; }
        }

        public string Sender
        {
            set { this._tbFrom.Text = value; }
        }

        public List<string> To
        {
            set { _lbTo.DataSource = value; }
        }

        public List<string> CC
        {
            set { _lbCc.DataSource = value; }
        }

        public List<string> BCC
        {
            set { _lbBcc.DataSource = value; }
        }

        public int NumberOfAttachments
        {
            set { _lblNumberOfAttachments.Text = value.ToString(); }
        }

        #endregion

        private void ConfirmationDialog_Load(object sender, EventArgs e)
        {
            this._btnDontSendIt.Focus();
            this._btnDontSendIt.Select();
        }

        private void _lbBccRecipients_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}