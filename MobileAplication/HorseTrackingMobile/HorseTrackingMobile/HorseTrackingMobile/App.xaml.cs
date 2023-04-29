using HorseTrackingMobile.Database;
using HorseTrackingMobile.Services;
using HorseTrackingMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorseTrackingMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DataBaseConnection.Connect();
            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
