﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HorseTrackingDesktop.Models
{
    public partial class Portions
    {
        public int PortionId { get; set; }
        public int ForageId { get; set; }
        public int UnitId { get; set; }
        public int MealId { get; set; }
        public double Amount { get; set; }

        public virtual Forages Forage { get; set; }
        public virtual Meals Meal { get; set; }
        public virtual UnitOfMeasures Unit { get; set; }
    }
}