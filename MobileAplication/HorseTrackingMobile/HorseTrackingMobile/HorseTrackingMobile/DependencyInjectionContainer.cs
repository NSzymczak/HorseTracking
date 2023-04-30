using HorseTrackingMobile.Database;
using HorseTrackingMobile.Database.ActivityServices;
using HorseTrackingMobile.Database.HorseServices;
using HorseTrackingMobile.Database.NutritionServices;
using HorseTrackingMobile.Database.UserServices;
using HorseTrackingMobile.Database.VisitServices;
using HorseTrackingMobile.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace HorseTrackingMobile
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionService, ConnectionService>();
            services.AddSingleton<BaseService>();
            services.AddSingleton<IHorseService, HorseService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IActivityService, ActivityService>();
            services.AddSingleton<IVisitService, VisitService>();
            services.AddSingleton<INutritionService, NutritionService>();
            return services;
        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddTransient<BaseViewModel>();
            services.AddTransient<HorseAppViewModel>();

            services.AddTransient<LoginViewModel>();

            services.AddTransient<ActivityViewModel>();
            services.AddTransient<ActivityDetailsViewModel>();
            services.AddTransient<AddActivityViewModel>();

            services.AddTransient<VisitDetailsViewModel>();
            services.AddTransient<VisitViewModel>();

            services.AddTransient<NutritionPlanViewModel>();

            return services;
        }
    }
}
