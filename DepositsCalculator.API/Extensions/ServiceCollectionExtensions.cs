using DepositsCalculator.BLL.Services;
using DepositsCalculator.BLL.Services.Interfaces;
using DepositsCalculator.ViewModels.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DepositsCalculator.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDepositCalculatorServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<DepositViewModelValidator>();

            services
                .AddTransient<IInterestsServiceFactory, InterestsServiceFactory>()
                .AddTransient<IInterestsService, SimpleInterestsService>()
                .AddTransient<IInterestsService, CompoundInterestsService>();

            return services;
        }
    }
}
