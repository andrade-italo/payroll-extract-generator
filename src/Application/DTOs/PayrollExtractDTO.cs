using PayrollExtractGenerator.Domain.ValueObjects;

namespace PayrollExtractGenerator.Application.DTOs
{
  public class PayrollExtractDTO
  {
    public string EmployeeName { get; set; }
    public string Period { get; set; }
    public decimal GrossSalary { get; set; }
    public decimal TotalDeductions { get; set; }
    public decimal NetSalary { get; set; }
    public List<Deductions> Deductions { get; set; }

  }
}
