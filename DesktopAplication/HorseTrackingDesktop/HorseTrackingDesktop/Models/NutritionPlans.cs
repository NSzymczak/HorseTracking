﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HorseTrackingDesktop.Models
{
    public partial class NutritionPlans
    {
        public NutritionPlans()
        {
            Diets = new HashSet<Diets>();
            Meals = new HashSet<Meals>();
        }

        public int NutritionPlanId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Icon { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Diets> Diets { get; set; }
        public virtual ICollection<Meals> Meals { get; set; }
    }
}