using Application.Common.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Extensions;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<StoreContext>(x =>
            {
                x.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<AppIdentityDbContext>(x => {
                x.UseSqlite(config.GetConnectionString("IdentityConnection"));
            });

            services.AddScoped<IStoreContext>(sp => sp.GetRequiredService<StoreContext>());

            services.AddIdentityService(config);

            services.AddScoped<IDomainEventService, DomainEventService>();
            
            services.AddScoped<ITokenService, TokenService>();

            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}
