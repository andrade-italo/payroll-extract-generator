using PayrollExtractGenerator.Application.Interfaces;
using PayrollExtractGenerator.Application.DTOs;
using PayrollExtractGenerator.Domain.Exceptions;
using PayrollExtractGenerator.Domain.Interfaces;
using PayrollExtractGenerator.Application.Mappers;

namespace PayrollExtractGenerator.Application.UseCases
{
  public class GetEmployeeByIdUseCase : IGetEmployeeByIdUseCase
  {
    private readonly IEmployeeRepository _employeeRepository;


    public GetEmployeeByIdUseCase(IEmployeeRepository employeeRepository)
    {
      _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeDTO> ExecuteAsync(long id)
    {
      var employee = await _employeeRepository.GetByIdAsync(id) ?? throw new EmployeeNotFoundException();

      return employee.MapToDto();
    }
  }
}
