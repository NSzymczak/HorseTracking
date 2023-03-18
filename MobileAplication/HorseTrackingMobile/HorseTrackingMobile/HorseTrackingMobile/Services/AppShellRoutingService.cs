using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HorseTrackingMobile.Views;

namespace HorseTrackingMobile.Services
{
    public class AppShellRoutingService
    {

        public AppShellRoutingService()
        {
            //Routings
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(ActivityView), typeof(ActivityView));
            Routing.RegisterRoute(nameof(ActivityDetailsView), typeof(ActivityDetailsView));
            Routing.RegisterRoute(nameof(AddActivityView), typeof(AddActivityView));
            Routing.RegisterRoute(nameof(VisitView), typeof(VisitView));

        }

        public void GoToApplication()
        {
            App.Current.MainPage = new AppShell();
        }

        public void GoToActivity()
        {
            Shell.Current.CurrentItem = AppShell.Activity;
        }

        public async void GoToLogin()
        {
            await Shell.Current.GoToAsync("//LoginView");
        }

        public async Task GoToAddActivity()
        {
            //await Shell.Current.GoToAsync(nameof(AddActivityView));
        }

    }
}
