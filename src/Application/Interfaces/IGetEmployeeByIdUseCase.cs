using PayrollExtractGenerator.Application.DTOs;

namespace PayrollExtractGenerator.Application.Interfaces
{
  public interface IGetEmployeeByIdUseCase : IUseCase<long, EmployeeDTO>
  { }
}
