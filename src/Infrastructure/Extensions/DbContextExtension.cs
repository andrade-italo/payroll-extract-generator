using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayrollExtractGenerator.Infrastructure.Context;

namespace PayrollExtractGenerator.Infrastructure.Extensions
{
  [ExcludeFromCodeCoverage]
  public static class DbContextExtension
  {
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
      string connectionString = configuration.GetConnectionString("PayrollExtractGeneratorDbContext");
      services.AddDbContext<PayrollExtractGeneratorDbContext>(
        options => options.UseSqlServer(connectionString));

      return services;
    }
  }
}
