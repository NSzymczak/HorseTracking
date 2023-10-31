using HorseTrackingMobile.Database;
using HorseTrackingMobile.Database.UserServices;
using HorseTrackingMobile.Services;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database;
using HorseTrackingMobile.Services.Database.ActivityServices;
using HorseTrackingMobile.Services.Database.CompetitionService;
using HorseTrackingMobile.Services.Database.HorseServices;
using HorseTrackingMobile.Services.Database.NutritionServices;
using HorseTrackingMobile.Services.Database.ShareHorseServices;
using HorseTrackingMobile.Services.Database.UserServices;
using HorseTrackingMobile.Services.Database.VisitServices;
using HorseTrackingMobile.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace HorseTrackingMobile
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IAppShellRoutingService, AppShellRoutingService>();
            services.AddSingleton<IConnectionService, ConnectionService>();
            services.AddSingleton<IAppState, AppState>();
            services.AddSingleton<BaseDataService>();
            services.AddSingleton<IHorseService, HorseService>();
            services.AddSingleton<IActivityService, ActivityService>();
            services.AddSingleton<IVisitService, VisitService>();
            services.AddSingleton<INutritionService, NutritionService>();
            services.AddSingleton<IEncrypt, Encrypt>();
            services.AddSingleton<IShareHorseServices, ShareHorseServices>();
            services.AddSingleton<ICompetitionService, CompetitionService>();
            return services;
        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddTransient<LoginViewModel>();

            services.AddSingleton<BaseViewModel>();

            services.AddTransient<ActivityViewModel>();
            services.AddTransient<ActivityDetailsViewModel>();

            services.AddTransient<VisitDetailsViewModel>();
            services.AddTransient<VisitViewModel>();

            services.AddTransient<NutritionPlanViewModel>();

            services.AddTransient<ShareManagmentViewModel>();
            services.AddTransient<ShareHorseViewModel>();
            services.AddTransient<ScanHorseViewModel>();
            services.AddTransient<ShareHorseSearchViewModel>();

            services.AddTransient<CompetitionViewModel>();

            services.AddTransient<ChangePasswordViewModel>();
            return services;
        }
    }
}