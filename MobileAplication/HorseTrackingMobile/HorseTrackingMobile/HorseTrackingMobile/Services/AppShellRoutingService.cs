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
            Routing.RegisterRoute(nameof(AddVisitView), typeof(AddVisitView));
            Routing.RegisterRoute(nameof(ScanHorseView), typeof(ScanHorseView));
            Routing.RegisterRoute(nameof(ShareHorseView), typeof(ShareHorseView));
            Routing.RegisterRoute(nameof(ShareManagmentView), typeof(ShareManagmentView));
            Routing.RegisterRoute(nameof(ShareHorseSearchView), typeof(ShareHorseSearchView));
            Routing.RegisterRoute(nameof(ChangePasswordView), typeof(ChangePasswordView));
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

        public void GoToAddActivity(Activity activity)
        {
            Shell.Current.GoToAsync($"{nameof(AddActivityView)}?{nameof(ActivityDetailsViewModel.ActivityID)}={activity.ID}");
        }

        public void GoToAddVisit()
        {
            Shell.Current.GoToAsync(nameof(AddVisitView));
        }

        public void GoToShareManagment()
        {
            Shell.Current.GoToAsync(nameof(ShareManagmentView));
        }

        public void GoToScanHorses()
        {
            Shell.Current.GoToAsync(nameof(ScanHorseView));
        }

        public void GoToShareHorses()
        {
            Shell.Current.GoToAsync(nameof(ShareHorseView));
        }

        public void GoToShareBySearch()
        {
            Shell.Current.GoToAsync(nameof(ShareHorseSearchView));
        }

        public void GoToChangePassword()
        {
            Shell.Current.GoToAsync(nameof(ChangePasswordView));
        }
    }
}