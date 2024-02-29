using PayrollExtractGenerator.Domain.Entities;
using PayrollExtractGenerator.Application.DTOs;

namespace PayrollExtractGenerator.Application.Mappers
{
  public static class EmployeeMapperToEntity
  {
    public static Employee MapToEntity(this EmployeeDTO employeeDto)
    {
      return new Employee
      {
        FirstName = employeeDto.FirstName,
        LastName = employeeDto.LastName,
        Document = employeeDto.Document,
        Department = employeeDto.Department,
        GrossSalary = employeeDto.GrossSalary,
        HireDate = employeeDto.HireDate,
        HasHealthPlanDiscount = employeeDto.HasHealthPlanDiscount,
        HasDentalPlanDiscount = employeeDto.HasDentalPlanDiscount,
        HasTransportationVoucherDiscount = employeeDto.HasTransportationVoucherDiscount
      };
    }
  }
}
