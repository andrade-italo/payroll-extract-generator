namespace PayrollExtractGenerator.Domain.Entities
{
  public class Employee
  {
    public long Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Department { get; set; }
    public decimal GrossSalary { get; set; }
    public DateTime HireDate { get; set; }
    public bool HasHealthPlanDiscount { get; set; }
    public bool HasDentalPlanDiscount { get; set; }
    public bool HasTransportationVoucherDiscount { get; set; }
  }
}
