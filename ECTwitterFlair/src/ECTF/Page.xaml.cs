using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace ECTF
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            LoadXml();
        }

        private void LoadXml()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            wc.DownloadStringAsync(new Uri("friends_timeline.xml", UriKind.Relative));
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                HtmlPage.Window.Alert(e.Error.ToString());
                return;
            }

            XDocument xd = XDocument.Load(new StringReader(e.Result));
            lbTweets.DataContext = xd;
        }
    }
}
