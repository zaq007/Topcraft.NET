using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class Server
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Ip { get; set; }

        [ScaffoldColumn(false)]
        public int ProjectID { get; set; }

        public virtual ICollection<Mod> Mods { get; set; }

        [NotMapped]
        [ScaffoldColumn(false)]
        public int[] ModsId { get; set; }

        public virtual Project Project { get; set; }

        public Server()
        {
            Mods = new List<Mod>();
        }

    }
}