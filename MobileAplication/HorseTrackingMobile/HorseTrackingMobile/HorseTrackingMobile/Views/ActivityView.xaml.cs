using HorseTrackingMobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorseTrackingMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityView : ContentPage
    {
        ActivityViewModel modelView;
        public ActivityView()
        {
            InitializeComponent();
            modelView = Startup.ServiceProvider.GetService<ActivityViewModel>();
            BindingContext = modelView;
            Appearing += (s, e) => 
            { 
                modelView.Load(); 
            };
        }
    }
}