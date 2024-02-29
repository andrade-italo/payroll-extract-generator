using PayrollExtractGenerator.Application.Interfaces;
using PayrollExtractGenerator.Application.Mappers;
using PayrollExtractGenerator.Application.Services;
using PayrollExtractGenerator.Domain.Exceptions;
using PayrollExtractGenerator.Domain.Interfaces;
using PayrollExtractGenerator.Application.DTOs;

namespace PayrollExtractGenerator.Application.UseCases
{
  public class GeneratePayrollReportUseCase : IGeneratePayrollReportUseCase
  {

    private readonly IEmployeeRepository _employeeRepository;
    private readonly DeductionsCalculator _deductionsCalculator;


    public GeneratePayrollReportUseCase(IEmployeeRepository employeeRepository, DeductionsCalculator deductionsCalculator)
    {
      _employeeRepository = employeeRepository;
      _deductionsCalculator = deductionsCalculator;
    }

    public async Task<PayrollExtractDTO> ExecuteAsync(long employeeId)
    {
      var employee = await _employeeRepository.GetByIdAsync(employeeId) ?? throw new EmployeeNotFoundException();
      var deductionsList = _deductionsCalculator.CalculateAll(employee.GrossSalary);

      return employee.MapToPayrollExtractDTO(deductionsList);
    }
  }
}
