using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CounterApi.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base ("AppConnection")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Counter> Counters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<XApiKey> XApiKeys { get; set; }
    }
}