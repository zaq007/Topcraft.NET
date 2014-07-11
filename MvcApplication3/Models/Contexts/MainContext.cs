using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class MainContext : DbContext
    {
        public MainContext()
            : base("TestDB")
        {

        }

        public DbSet<Account> Accouts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Mod> Mods { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Price> Prices { get; set; }
        
    }
}