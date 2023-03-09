﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HorseTrackingDesktop.Models
{
    public partial class Horse
    {
        public Horse()
        {
            Activity = new HashSet<Activity>();
            CustomNotification = new HashSet<CustomNotification>();
            Eat = new HashSet<Eat>();
            Shared = new HashSet<Shared>();
            TakePart = new HashSet<TakePart>();
            Visit = new HashSet<Visit>();
        }

        public int HorseId { get; set; }
        public int GenderId { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Mother { get; set; }
        public string Father { get; set; }
        public DateTime? Birthday { get; set; }
        public string Race { get; set; }
        public string Breeder { get; set; }
        public string Passport { get; set; }
        public string Photo { get; set; }

        public virtual HorseGender Gender { get; set; }
        public virtual HorseStatus Status { get; set; }
        public virtual UserAcount User { get; set; }
        public virtual ICollection<Activity> Activity { get; set; }
        public virtual ICollection<CustomNotification> CustomNotification { get; set; }
        public virtual ICollection<Eat> Eat { get; set; }
        public virtual ICollection<Shared> Shared { get; set; }
        public virtual ICollection<TakePart> TakePart { get; set; }
        public virtual ICollection<Visit> Visit { get; set; }

        public static List<Horse> Horses { get; set; }
    }
}