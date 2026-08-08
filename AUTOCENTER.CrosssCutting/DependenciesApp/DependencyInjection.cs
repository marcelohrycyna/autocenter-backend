using AUTOCENTER.Service.AutoMapper;
using AUTOCENTER.Service.Interfaces;
using AUTOCENTER.Service.Services;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace AUTOCENTER.CrosssCutting.DependenciesApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.Scan(i =>
                i.FromAssemblies(Assembly.Load("AUTOCENTER.Service"))
                .AddClasses(c => c.WithAttribute<ScopedAttribute>())
                .AsImplementedInterfaces()
                .WithScopedLifetime()

                .AddClasses(c => c.WithAttribute<TransientAttribute>())
                .AsImplementedInterfaces()
                .WithTransientLifetime()

                .AddClasses(c => c.WithAttribute<SingletonAttribute>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime()
            );

            services.AddSingleton(AutoMapperConfig.RegisterAutoMapper());

            return services;
        }
    }
}