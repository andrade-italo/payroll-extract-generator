using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using PayrollExtractGenerator.Domain.Entities;

namespace PayrollExtractGenerator.Infrastructure.Context
{
  [ExcludeFromCodeCoverage]

  public class PayrollExtractGeneratorDbContext : DbContext
  {
    public PayrollExtractGeneratorDbContext(DbContextOptions<PayrollExtractGeneratorDbContext> options) : base(options)
    { }
    public DbSet<Employee> Employees { get; set; }

    private static Type TypeContext => typeof(PayrollExtractGeneratorDbContext);
    private static string DefaultSchema => "dbo";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema(DefaultSchema);
      modelBuilder.ApplyConfigurationsFromAssembly(TypeContext.Assembly);
      modelBuilder.Entity<Employee>()
          .Property(employee => employee.Id)
          .ValueGeneratedOnAdd();
    }
  }
}
