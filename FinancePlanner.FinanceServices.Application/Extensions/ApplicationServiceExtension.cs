using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FinancePlanner.FinanceServices.Application.Behaviours;
using FinancePlanner.FinanceServices.Application.Services.IncomeInformationServices;
using FinancePlanner.FinanceServices.Application.Services.PayInformationServices;

namespace FinancePlanner.FinanceServices.Application.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        Assembly assemblies = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assemblies);
        services.AddValidatorsFromAssembly(assemblies);
        services.AddMediatR(assemblies);
        services.AddScoped<IPayInformationService, PayInformationService>();
        services.AddScoped<IIncomeInformationService, IncomeInformationService>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        return services;
    }
}