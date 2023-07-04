using HorseTrackingMobile.Services;
using HorseTrackingMobile.ViewModels;
using HorseTrackingMobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HorseTrackingMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {

        public AppShellRoutingService RoutingServices { get; }
        public static ShellContent Activity { get; set; }


        public AppShell()
        {
            InitializeComponent();
            RoutingServices=new AppShellRoutingService();
            Activity = activity;
        }

        public void Logout(object sender, EventArgs e)
        {
            Preferences.Set(PreferencesKeys.UserID, 0);

            RoutingServices.GoToLogin();
        }

    }
}
