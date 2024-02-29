namespace PayrollExtractGenerator.Domain.Exceptions
{
  public class EmployeeNotFoundException : Exception
  {
    public EmployeeNotFoundException() : base("Employee not found.")
    {
    }

    public EmployeeNotFoundException(string message) : base(message)
    {
    }

    public EmployeeNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}
