using HorseTrackingMobile.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorseTrackingMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NutritionPlanView : ContentPage
    {
        private readonly NutritionPlanViewModel viewModel;
        public NutritionPlanView()
        {
            InitializeComponent();
            viewModel = new NutritionPlanViewModel();
            BindingContext = viewModel;
            Appearing += (s, e) =>
            {
                viewModel.Load();
            };
        }
    }
}