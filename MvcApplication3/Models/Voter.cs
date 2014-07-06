using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class Voter
    {
        public int Id { get; set; }

        public string Vk { get; set; }

        public DateTime LastVote { get; set; }
    }
}