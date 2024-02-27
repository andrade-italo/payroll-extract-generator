using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PayrollExtractGenerator.Infrastructure.Context;

namespace PayrollExtractGenerator.Infrastructure.Extensions
{
  [ExcludeFromCodeCoverage]
  public static class DbContextExtension
  {
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
      return services.AddDbContext<PayrollExtractGeneratorDbContext>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
    }
  }
}
