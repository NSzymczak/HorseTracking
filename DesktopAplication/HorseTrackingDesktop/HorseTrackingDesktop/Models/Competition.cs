﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HorseTrackingDesktop.Models
{
    public partial class Competition
    {
        public Competition()
        {
            TakePart = new HashSet<TakePart>();
        }

        public int CompetitionId { get; set; }
        public string Spot { get; set; }
        public string Rank { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TakePart> TakePart { get; set; }
    }
}