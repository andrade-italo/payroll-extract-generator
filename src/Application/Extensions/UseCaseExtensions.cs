using PayrollExtractGenerator.Application.UseCases;
using PayrollExtractGenerator.Application.Interfaces;
using PayrollExtractGenerator.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace PayrollExtractGenerator.Application.Extensions
{
  public static class UseCaseExtensions
  {
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
      services.AddScoped<DeductionsCalculator>();
      services.AddScoped<ICreateEmployeeUseCase, CreateEmployeeUseCase>();
      services.AddScoped<IGetEmployeeByIdUseCase, GetEmployeeByIdUseCase>();
      services.AddScoped<IGeneratePayrollReportUseCase, GeneratePayrollReportUseCase>();

      return services;
    }
  }
}
