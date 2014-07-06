using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class Mod
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Server> Servers { get; set; }

        public Mod()
        {
            Servers = new List<Server>();
        }
    }
}