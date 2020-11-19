using Application.Common.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<StoreContext>(x =>
            {
                x.UseSqlite(config.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(StoreContext).Assembly.FullName));
            });

            services.AddScoped<IStoreContext>(sp => sp.GetRequiredService<StoreContext>());
            services.AddScoped<IDomainEventService, DomainEventService>();

            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}
