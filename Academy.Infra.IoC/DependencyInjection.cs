using Academy.Application.Interfaces;
using Academy.Application.Mappings;
using Academy.Application.Services;
using Academy.Domain.Interfaces;
using Academy.Infra.Context.Data;
using Academy.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Academy.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // EF Context
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Repository
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Service
            services.AddAutoMapper(typeof(DomainDTOMappingProfile));
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
