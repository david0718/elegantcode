using System;
using System.Xml.Linq;

namespace ECTF.Domain
{
    public class TwitterUser
    {
        public TwitterUser(string screenName, string imgUrl)
        {
            ScreenName = screenName;
            ImgUri = imgUrl;
        }

        public string ScreenName { get; private set; }
        public string ImgUri { get; private set; }
    }

    public class TwitterUserAdapter
    {
        public TwitterUser GetTwitterUser(XElement xml)
        {
            throw new NotImplementedException();
        }
    }
}