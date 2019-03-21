using SnmpSharpNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace KopitekCounter
{
    class Counter
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Serial { get; set; }
        public string Ip { get; set; }
        public string A4101 { get; set; }
        public string A3112 { get; set; }
        public string A4113 { get; set; }
        public string A3122Color { get; set; }
        public string A4123Color { get; set; }
        public string Print301 { get; set; }
        public DateTime UpdateTime { get; set; }
        public string LastStatus { get; set; }


        public Counter GetCounter(string ip)
        {
        
            try
            {
                var registry = new Registry();
                var name = GetCounters(ip, "1.3.6.1.2.1.1.1.0");
                var serial = GetCounters(ip, "1.3.6.1.4.1.1602.1.2.1.4.0");
                if (name.Contains("LBP"))
                    serial = GetCounters(ip, "1.3.6.1.2.1.2.2.1.6.1");

                var counter = new Counter()
                {
                    CustomerId = Int32.Parse(registry.GetRecord("CustomerId")),
                    Serial = serial,
                    Ip = ip,
                    A4101 = GetCounters(ip, "1.3.6.1.2.1.43.10.2.1.4.1.1"),
                    A3112 = GetCounters(ip, "1.3.6.1.4.1.1602.1.11.1.3.1.4.112"),
                    A4113 = GetCounters(ip, "1.3.6.1.4.1.1602.1.11.1.3.1.4.113"),
                    A3122Color = GetCounters(ip, "1.3.6.1.4.1.1602.1.11.1.3.1.4.122"),
                    A4123Color = GetCounters(ip, "1.3.6.1.4.1.1602.1.11.1.3.1.4.123"),
                    Print301 = GetCounters(ip, "1.3.6.1.4.1.1602.1.11.1.3.1.4.301"),
                    LastStatus = "Offline"
                };

                if (counter.A4101 != "-")
                    counter.LastStatus = "Online";
                var logger = new Logger();
                logger.ErrorLog(counter.A4101);
                return counter;
            }

            catch(Exception ex)
            {
                var logger = new Logger();
                logger.ErrorLog(ex.ToString());
                return null;
            }
        }

        private string GetCounters(string ip, string query)
        {
            try
            {
                OctetString community = new OctetString("public");
                AgentParameters param = new AgentParameters(community);
                param.Version = SnmpVersion.Ver1;
                IpAddress agent = new IpAddress(ip);
                UdpTarget target = new UdpTarget((IPAddress)agent, 161, 3000, 1);

                Pdu pdu = new Pdu(PduType.Get);
                pdu.VbList.Add(query);
                SnmpV1Packet result = (SnmpV1Packet)target.Request(pdu, param);

                if (result != null)
                    return result.Pdu.VbList[0].Value.ToString();

                else return "-";
            }
            catch
            {
                    return "-";
            }
        }
    }
}
