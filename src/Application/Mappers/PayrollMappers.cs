using PayrollExtractGenerator.Domain.Entities;
using PayrollExtractGenerator.Application.DTOs;
using PayrollExtractGenerator.Domain.ValueObjects;

namespace PayrollExtractGenerator.Application.Mappers
{
  public static class PayrollMapper
  {
    public static PayrollExtractDTO MapToPayrollExtractDTO(this Employee employee, List<Deductions> deductionsList)
    {
      var totalDeductions = deductionsList.Sum(d => d.Value);
      return new PayrollExtractDTO
      {
        EmployeeName = $"{employee.FirstName} {employee.LastName}",
        Period = DateTime.Now.ToString("yyyy-MM"),
        GrossSalary = employee.GrossSalary,
        TotalDeductions = -totalDeductions,
        NetSalary = employee.GrossSalary - totalDeductions,
        Deductions = deductionsList
      };
    }
  }
}
