using FinancePlanner.FinanceServices.Infrastructure.Persistence;
using FinancePlanner.FinanceServices.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancePlanner.FinanceServices.Infrastructure.Extensions;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<FinanceDbContext>(options =>
            options.UseSqlServer(config.GetSection("ConnectionStrings:DatabaseConnection").Value));
        services.AddScoped<IPayInformationRepository, PayInformationRepository>();
        services.AddScoped<IIncomeInformationRepository, IncomeInformationRepository>();
        return services;
    }
}