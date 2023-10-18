using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace LinkUp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            //    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

            return services;
        }
    }
}
