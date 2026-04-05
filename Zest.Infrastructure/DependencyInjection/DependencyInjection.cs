using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zest.Application.Interfaces;
using Zest.Domain.Interfaces;
using Zest.Infrastructure.Data;
using Zest.Infrastructure.Repositories;
using Zest.Infrastructure.Services;

namespace Zest.Infrastructure.DependencyInjection
{
   

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            // repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // register a service is here 
            services.AddScoped<IJWTService, JwtService>();
            return services;
        }
    }
}
