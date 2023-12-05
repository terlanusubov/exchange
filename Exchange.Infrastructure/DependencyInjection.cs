using Exchange.Application.Interfaces;
using Exchange.Domain.Repositories;
using Exchange.Infrastructure.Persistance;
using Exchange.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Exchange.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration["Database:ConnectionString"]);
            });


            services.AddTransient<IExchangeService, ExchangeService>();

            services.AddScoped<IOperationRepository, OperationRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
