﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HorseTrackingDesktop.Models
{
    public partial class Specialisations
    {
        public Specialisations()
        {
            Professionals = new HashSet<Professionals>();
        }

        public int SpecialisationId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Professionals> Professionals { get; set; }
    }
}