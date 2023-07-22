using Microsoft.Extensions.DependencyInjection;
using System;

namespace HorseTrackingDesktop
{
    public static class StartUp
    {
        public static IServiceProvider? ServiceProvider { get; set; }

        public static IServiceProvider Init()
        {
            var serviceProvider = new ServiceCollection()
                .ConfigureServices()
                .ConfigureViewModels()
                .BuildServiceProvider();

            ServiceProvider = serviceProvider;

            return serviceProvider;
        }
    }
}