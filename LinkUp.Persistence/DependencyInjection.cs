using LinkUp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<LinkUpDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ILinkUpDbContext>(provider =>
                provider.GetService<LinkUpDbContext>());

            return services;
        }
    }
}
