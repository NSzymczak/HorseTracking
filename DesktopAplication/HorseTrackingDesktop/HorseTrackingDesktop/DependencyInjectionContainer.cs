using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.Services.Database.UserService;
using HorseTrackingDesktop.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IAppState,AppState>();
            services.AddSingleton<IUserServices, UserSevices>();
            return services;
        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddSingleton<BaseViewModel>();
            services.AddTransient<LoginViewModel>();

            return services;
        }
    }
}
