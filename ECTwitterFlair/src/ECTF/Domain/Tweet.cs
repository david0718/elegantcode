using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ECTF.Domain
{
    public class Tweet
    {
        public Tweet(string message, TwitterUser user)
        {
            Message = message;
            User = user;
        }

        public string Message { get; private set; }
        public TwitterUser User { get; private set; }
    }
}
