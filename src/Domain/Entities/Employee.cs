namespace PayrollExtractGenerator.Domain.Entities
{
  public class Employee
  {
    public long Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Document { get; private set; }
    public string Department { get; private set; }
    public decimal GrossSalary { get; private set; }
    public DateTime HireDate { get; private set; }
    public bool HasHealthPlanDiscount { get; private set; }
    public bool HasDentalPlanDiscount { get; private set; }
    public bool HasTransportationVoucherDiscount { get; private set; }
  }
}
