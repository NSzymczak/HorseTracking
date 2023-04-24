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
            modelView = new ActivityViewModel();
            BindingContext = modelView;
            Appearing += (s, e) => 
            { 
                modelView.Load(); 
            };
        }

        private void SwichHorse(object sender, EventArgs e)
        {
            modelView.SwitchHorseCommand.Execute(true);
        }
    }
}