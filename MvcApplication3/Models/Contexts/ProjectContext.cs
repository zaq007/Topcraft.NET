using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
            : base("TestDB")
        {

        }

        public DbSet<Project> Entries { get; set; }
    }
}