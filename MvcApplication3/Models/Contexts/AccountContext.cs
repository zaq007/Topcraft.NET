using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class AccountContext : DbContext
    {
        public AccountContext()
            : base("TestDB")
        {

        }

        public DbSet<Account> Entries { get; set; }
    }
}