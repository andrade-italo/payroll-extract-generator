namespace PayrollExtractGenerator.Application.Strategies
{
  public class ProgressiveTaxCalculationStrategy : ITaxCalculationStrategy
  {
    private readonly decimal _salary;
    private readonly decimal _rate;
    private readonly decimal _deduction;

    public ProgressiveTaxCalculationStrategy(decimal salary, decimal rate, decimal deduction)
    {
      _salary = salary;
      _rate = rate;
      _deduction = deduction;
    }

    public decimal Calculate()
    {
      decimal tax = _salary * _rate;
      return tax > _deduction ? _deduction : tax;
    }
  }
}