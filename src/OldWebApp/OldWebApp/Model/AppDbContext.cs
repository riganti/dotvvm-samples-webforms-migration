using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OldWebApp.Model
{
    public class AppDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }

        public AppDbContext() : base("DB")
        {
        }
    }
}