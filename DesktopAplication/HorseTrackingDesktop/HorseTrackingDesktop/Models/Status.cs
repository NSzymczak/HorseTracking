﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HorseTrackingDesktop.Models
{
    public partial class Status
    {
        public Status()
        {
            Horses = new HashSet<Horses>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Horses> Horses { get; set; }
    }
}