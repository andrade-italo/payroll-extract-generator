using Microsoft.EntityFrameworkCore;
using PayrollExtractGenerator.Domain.Entities;
using PayrollExtractGenerator.Domain.Interfaces;

namespace PayrollExtractGenerator.Infrastructure.Repositories
{
  public class EmployeeRepository : IEmployeeRepository
  {
    private readonly DbContext _dbContext;

    public EmployeeRepository(DbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<Employee> GetByIdAsync(long id)
    {
      return await _dbContext.Set<Employee>().FindAsync(id);
    }

    public async Task AddAsync(Employee employee)
    {
      _dbContext.Set<Employee>().Add(employee);
      await _dbContext.SaveChangesAsync();
    }
  }
}
