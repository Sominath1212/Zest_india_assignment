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
    /// <summary>
    /// Registers a dependencies in the container.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add all the dependencies for the infrastructure layer in the container.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
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
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();  

            // register a service is here 
            services.AddScoped<IJWTService, JwtService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
