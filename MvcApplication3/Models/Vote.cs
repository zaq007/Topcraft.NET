using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public string Ip { get; set; }

        public string Nickname { get; set; }

        public int ProjectId { get; set; }

        public DateTime Date { get; set; }

        public virtual Project Project { get; set; }

    }
}