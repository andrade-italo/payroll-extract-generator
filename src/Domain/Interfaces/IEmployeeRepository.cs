using System.Threading.Tasks;
using PayrollExtractGenerator.Domain.Entities;

namespace PayrollExtractGenerator.Domain.Interfaces
{
  public interface IEmployeeRepository
  {
    Task<Employee> GetByIdAsync(long id);
    Task<Employee> AddAsync(Employee employee);
  }
}
