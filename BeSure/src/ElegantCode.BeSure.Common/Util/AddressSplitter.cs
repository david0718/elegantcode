using System;
using System.Collections.Generic;

namespace ElegantCode.BeSure.Common.Util
{
    public class AddressSplitter
    {
        public static List<string> SplitAddresses(string joinedEmails)
        {
            var addresses = new List<string>();

            if (String.IsNullOrEmpty(joinedEmails))
            {
                return addresses;
            }

            foreach (string address in joinedEmails.Split(';'))
            {
                addresses.Add(address.Trim());
            }

            return addresses;
        }
    }
}