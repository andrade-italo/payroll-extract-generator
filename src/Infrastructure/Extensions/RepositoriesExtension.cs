using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PayrollExtractGenerator.Domain.Interfaces;
using PayrollExtractGenerator.Infrastructure.Repositories;

namespace PayrollExtractGenerator.Infrastructure.Extensions
{
  [ExcludeFromCodeCoverage]
  public static class RepositoriesExtension
  {
    public static IServiceCollection AddRepositories(this IServiceCollection services)
      => services.AddScoped<IEmployeeRepository, EmployeeRepository>();
  }
}
