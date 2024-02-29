using PayrollExtractGenerator.Domain.Entities;
using PayrollExtractGenerator.Application.DTOs;

namespace PayrollExtractGenerator.Application.Mappers
{
  public static class EmployeeMapperToDTO
  {
    public static EmployeeDTO MapToDto(this Employee employee)
    {
      return new EmployeeDTO
      {
        Id = employee.Id,
        FirstName = employee.FirstName,
        LastName = employee.LastName,
        Document = employee.Document,
        Department = employee.Department,
        GrossSalary = employee.GrossSalary,
        HireDate = employee.HireDate,
        HasHealthPlanDiscount = employee.HasHealthPlanDiscount,
        HasDentalPlanDiscount = employee.HasDentalPlanDiscount,
        HasTransportationVoucherDiscount = employee.HasTransportationVoucherDiscount
      };
    }
  }
}
