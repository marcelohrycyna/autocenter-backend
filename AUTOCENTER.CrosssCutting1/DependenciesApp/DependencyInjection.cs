//using Fluent.Infrastructure.FluentModel;
using AUTOCENTER.Infra.Repositories;
using AUTOCENTER.Infra.Repositories.Interfaces;
using Fluent.Infrastructure.FluentStartup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AUTOCENTER.CrosssCutting.DependenciesApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));
            // Example: services.AddScoped<IMyService, MyService>();
            services.AddScoped<IPaisRepository, PaisRepository>();
            return services;
        }
    }
}
