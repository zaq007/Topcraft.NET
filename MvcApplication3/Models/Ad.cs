using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class Ad
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DataType(DataType.Url)]
        public string Url { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Banner { get; set; }

        public string Alt { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Start { get; set; }

        public Position Position { get; set; }

        public Goals Goal { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? EndTime { get; set; }

        [ScaffoldColumn(false)]
        public int Clicks { get; set; }

        [ScaffoldColumn(false)]
        public int EndClicks { get; set; }

        [ScaffoldColumn(false)]
        public int EndViews { get; set; }

        [ScaffoldColumn(false)]
        public int Views { get; set; }

        [ScaffoldColumn(false)]
        public int OwnerId { get; set; }

        public virtual Account Owner { get; set; }

        [ScaffoldColumn(false)]
        public virtual bool IsActive
        {
            get
            {
                return ((Goal == MvcApplication3.Models.Goals.Clicks && Clicks < EndClicks) ||
                        (Goal == MvcApplication3.Models.Goals.Time && DateTime.Now < EndTime) ||
                        (Goal == MvcApplication3.Models.Goals.View && Views < EndViews));
            }
        }
    }

    public enum Position
    {
        Bottom,
        Top,
        Floating
    }

    public enum Goals 
    {
        Clicks,
        View,
        Time
    }

}