﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HorseTrackingDesktop.Models
{
    public partial class Meal
    {
        public Meal()
        {
            Feeding = new HashSet<Feeding>();
        }

        public int MealId { get; set; }
        public string MealName { get; set; }

        public virtual ICollection<Feeding> Feeding { get; set; }
    }
}