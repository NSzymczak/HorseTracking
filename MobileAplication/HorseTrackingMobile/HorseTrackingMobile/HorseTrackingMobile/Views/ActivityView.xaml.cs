using HorseTrackingMobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorseTrackingMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityView : ContentPage
    {
        public ActivityView()
        {
            InitializeComponent();
            var activityViewModel= new ActivityViewModel();
            BindingContext = activityViewModel;
            Appearing += (s, e) => { activityViewModel.Load(); };
        }
    }
}