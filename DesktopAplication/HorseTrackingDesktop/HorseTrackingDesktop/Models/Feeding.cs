﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HorseTrackingDesktop.Models
{
    public partial class Feeding
    {
        public int FeedId { get; set; }
        public int NutritionPlanId { get; set; }
        public int ForageId { get; set; }
        public int UnitId { get; set; }
        public int MealId { get; set; }
        public double? Amount { get; set; }

        public virtual Forage Forage { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual NutritionPlan NutritionPlan { get; set; }
        public virtual UnitOfMeasure Unit { get; set; }
    }
}