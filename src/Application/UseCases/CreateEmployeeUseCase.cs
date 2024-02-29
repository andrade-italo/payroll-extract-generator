using PayrollExtractGenerator.Application.Interfaces;
using PayrollExtractGenerator.Application.DTOs;
using PayrollExtractGenerator.Domain.Interfaces;
using PayrollExtractGenerator.Application.Mappers;

namespace PayrollExtractGenerator.Application.UseCases
{
  public class CreateEmployeeUseCase : ICreateEmployeeUseCase
  {
    private readonly IEmployeeRepository _employeeRepository;


    public CreateEmployeeUseCase(IEmployeeRepository employeeRepository)
    {
      _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeDTO> ExecuteAsync(EmployeeDTO input)
    {
      var employee = input.MapToEntity();
      var employeeCreated = await _employeeRepository.AddAsync(employee);

      return employeeCreated.MapToDto();
    }
  }
}
