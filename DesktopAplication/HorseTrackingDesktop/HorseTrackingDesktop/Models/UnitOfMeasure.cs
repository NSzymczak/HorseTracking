﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HorseTrackingDesktop.Models
{
    public partial class UnitOfMeasure
    {
        public UnitOfMeasure()
        {
            Feeding = new HashSet<Feeding>();
            Forage = new HashSet<Forage>();
        }

        public int UnitId { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<Feeding> Feeding { get; set; }
        public virtual ICollection<Forage> Forage { get; set; }
    }
}