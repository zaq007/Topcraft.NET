using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class ServerContext : DbContext
    {
        public ServerContext()
            : base("TestDB")
        {

        }

        public DbSet<Account> Accouts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Mod> Mods { get; set; }
        public DbSet<Server> Servers { get; set; }
        
    }
}