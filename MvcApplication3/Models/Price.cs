using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class Price
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public Position Position { get; set; }

        public Goals Goal { get; set; }

        public int Cost { get; set; }
    }
}