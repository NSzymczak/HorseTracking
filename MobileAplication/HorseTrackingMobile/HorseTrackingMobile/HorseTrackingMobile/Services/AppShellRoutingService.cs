using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HorseTrackingMobile.Views;
using HorseTrackingMobile.ViewModels;
using HorseTrackingMobile.Models;

namespace HorseTrackingMobile.Services
{
    public class AppShellRoutingService : IAppShellRoutingService
    {

        public AppShellRoutingService()
        {
            //Routings
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(ActivityView), typeof(ActivityView));
            Routing.RegisterRoute(nameof(ActivityDetailsView), typeof(ActivityDetailsView));
            Routing.RegisterRoute(nameof(AddActivityView), typeof(AddActivityView));
            Routing.RegisterRoute(nameof(VisitView), typeof(VisitView));
            Routing.RegisterRoute(nameof(VisitDetailsView), typeof(VisitDetailsView));
            Routing.RegisterRoute(nameof(NutritionPlanView), typeof(NutritionPlanView));
            Routing.RegisterRoute(nameof(CompetitionView), typeof(CompetitionView));

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
        
        public void GoToActivityDetails(Activity activity)
        {
            Shell.Current.GoToAsync($"{nameof(ActivityDetailsView)}?{nameof(ActivityDetailsViewModel.ActivityID)}={activity.ID}");
        }

        public void GoToAddActivity()
        {
            Shell.Current.GoToAsync(nameof(AddActivityView));
        }

    }
}
