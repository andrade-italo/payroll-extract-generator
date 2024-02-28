using PayrollExtractGenerator.Domain.Entities;
using PayrollExtractGenerator.Domain.Interfaces;
using PayrollExtractGenerator.Infrastructure.Context;

namespace PayrollExtractGenerator.Infrastructure.Repositories
{
  public class EmployeeRepository : IEmployeeRepository
  {
    private readonly PayrollExtractGeneratorDbContext _dbContext;

    public EmployeeRepository(PayrollExtractGeneratorDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<Employee> GetByIdAsync(long id)
    {
      return await _dbContext.Set<Employee>().FindAsync(id);
    }

    public async Task<long> AddAsync(Employee employee)
    {
      _dbContext.Set<Employee>().Add(employee);
      await _dbContext.SaveChangesAsync();
      return employee.Id;
    }
  }
}
