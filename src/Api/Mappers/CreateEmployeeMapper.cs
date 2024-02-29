using PayrollExtractGenerator.Application.DTOs;
using PayrollExtractGenerator.Api.Models;

namespace PayrollExtractGenerator.Api.Mappers
{
  public static class CreateEmployeeMapper
  {
    public static EmployeeDTO MapToDTO(this CreateEmployeeRequest request)
    {
      return new EmployeeDTO
      {
        FirstName = request.FirstName,
        LastName = request.LastName,
        Document = request.Document,
        Department = request.Department,
        GrossSalary = request.GrossSalary,
        HireDate = request.HireDate,
        HasHealthPlanDiscount = request.HasHealthPlanDiscount,
        HasDentalPlanDiscount = request.HasDentalPlanDiscount,
        HasTransportationVoucherDiscount = request.HasTransportationVoucherDiscount
      };
    }
  }
}
