﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HorseTrackingDesktop.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Visit = new HashSet<Visit>();
        }

        public int DoctorId { get; set; }
        public int SpecialisationId { get; set; }
        public int DetailsId { get; set; }

        public virtual PeopleDetails Details { get; set; }
        public virtual DoctorSpecialisation Specialisation { get; set; }
        public virtual ICollection<Visit> Visit { get; set; }
    }
}