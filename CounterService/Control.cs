using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;

namespace KopitekCounter
{
    class Control
    {
        private static readonly Regex validIpV4AddressRegex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$", RegexOptions.IgnoreCase);
        public bool ipcontrol(string address)
        {
            if (address != "" || address != null)
                return validIpV4AddressRegex.IsMatch(address.Trim());
          

            return false;

        }

        public bool status(string sIp)
        {
            int timeout = 120;
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(sIp, timeout);
            if (reply.Status == IPStatus.Success)
                return true;
        
                return false;
        

        }
    }
}
