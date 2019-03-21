using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CounterApi.Models
{
    public class Counter
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

    }
}