﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HorseTrackingDesktop.Models
{
    public partial class UserAcounts
    {
        public UserAcounts()
        {
            ActivitiesTrainer = new HashSet<Activities>();
            ActivitiesUser = new HashSet<Activities>();
            Horses = new HashSet<Horses>();
            Notifications = new HashSet<Notifications>();
            SharedsUserScan = new HashSet<Shareds>();
            SharedsUserShare = new HashSet<Shareds>();
        }

        public int UserId { get; set; }
        public int TypeId { get; set; }
        public int DetailId { get; set; }
        public string Login { get; set; }
        public string Hash { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public virtual PeopleDetails Detail { get; set; }
        public virtual UserTypes Type { get; set; }
        public virtual ICollection<Activities> ActivitiesTrainer { get; set; }
        public virtual ICollection<Activities> ActivitiesUser { get; set; }
        public virtual ICollection<Horses> Horses { get; set; }
        public virtual ICollection<Notifications> Notifications { get; set; }
        public virtual ICollection<Shareds> SharedsUserScan { get; set; }
        public virtual ICollection<Shareds> SharedsUserShare { get; set; }
    }
}