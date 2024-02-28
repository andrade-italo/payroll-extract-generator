namespace PayrollExtractGenerator.Application.Strategies
{
  public class FGTSCalculator : ICalculationStrategy
  {
    private const decimal FGTSRate = 0.06m;

    public decimal Calculate(decimal grossSalary)
    {
      return grossSalary * FGTSRate;
    }
  }
}
