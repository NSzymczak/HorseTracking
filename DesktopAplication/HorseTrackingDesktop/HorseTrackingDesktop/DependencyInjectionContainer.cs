using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.PageModel;
using HorseTrackingDesktop.PageModel.Main;
using HorseTrackingDesktop.PageModel.Management;
using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.Services.Database.CalendarService;
using HorseTrackingDesktop.Services.Database.CompetitionService;
using HorseTrackingDesktop.Services.Database.HorseService;
using HorseTrackingDesktop.Services.Database.NutritionService;
using HorseTrackingDesktop.Services.Database.UserService;
using HorseTrackingDesktop.Services.Database.VisitService;
using HorseTrackingDesktop.Services.Hasher;
using HorseTrackingDesktop.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace HorseTrackingDesktop
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IAppState, AppState>();
            services.AddSingleton<IUserServices, UserSevices>();
            services.AddSingleton<IVisitService, VisitService>();
            services.AddSingleton<IHorseService, HorseService>();
            services.AddSingleton<INutritionService, NutritionService>();
            services.AddSingleton<ICompetitionService, CompetitionService>();
            services.AddSingleton<IHasher, Hasher>();
            services.AddSingleton<ICalendarService, CalendarService>();
            services.AddSingleton<HorseTrackingContext>();
            return services;
        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddSingleton<BaseViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<StatisticPageModel>();
            services.AddTransient<UserPageModel>();
            services.AddTransient<VisitPageModel>();
            services.AddTransient<NutritionPageModel>();
            services.AddTransient<AddVisitViewModel>();
            //services.AddTransient<ImageViewModel>();
            services.AddTransient<HorseManagmentPageModel>();
            services.AddTransient<ProfessionalManagementPageModel>();
            services.AddTransient<UserManagementPageModel>();
            services.AddTransient<AddUserForHorseViewModel>();
            services.AddTransient<AddNutritionViewModel>();
            services.AddTransient<SelectHorseViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<AcountPageModel>();
            services.AddTransient<CompetitionPageModel>();
            services.AddTransient<AddCompetitionViewModel>();
            services.AddTransient<CalendarPageModel>();
            return services;
        }
    }
}