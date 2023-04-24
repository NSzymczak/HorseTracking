﻿using HorseTrackingMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorseTrackingMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisitView : ContentPage
    {
        public VisitView()
        {
            InitializeComponent();
            var visitViewModel = new VisitViewModel();
            BindingContext = visitViewModel;
            Appearing += (s, e) => { visitViewModel.Load(); };
        }
    }
}