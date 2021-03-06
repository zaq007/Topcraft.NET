﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class Project
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.ImageUrl, ErrorMessage="You must write correct path to image!")]
        public string BannerUrl { get; set; }

        [DataType(DataType.Url)]
        [Required]
        public string SiteUrl { get; set; }

        [ScaffoldColumn(false)]
        public string RewardHash { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Url)]
        public string RewardUrl { get; set; }

        [ScaffoldColumn(false)]
        public int OwnerID { get; set; }

        public virtual Account Owner { get; set; }

        public virtual ICollection<Server> Servers { get; set; }

        [ScaffoldColumn(false)]
        public virtual int Votes { get { return VotesList.Count; } }

        [ScaffoldColumn(false)]
        public virtual int ServersCount { get { return Servers.Count; } }

        [ScaffoldColumn(false)]
        public virtual int TodayVotes { get { return VotesList.Where(x => DateTime.Now - x.Date < new TimeSpan(24, 0, 0)).ToList().Count; } }

        [ScaffoldColumn(false)]
        public Statuses Status { get; set; }

        public virtual ICollection<Vote> VotesList { get; set; }

        public Project()
        {
            VotesList = new List<Vote>();
            Servers = new List<Server>();
        }
    }

    public enum Statuses
    {
        Unconfirmed,
        Ordinary,
        Vip,
        Partner,
        Hidden
    }
}