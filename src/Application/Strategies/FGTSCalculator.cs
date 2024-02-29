namespace PayrollExtractGenerator.Application.Strategies
{
  public class FGTSCalculator : ICalculationStrategy
  {
    private const decimal FGTSRate = 0.08m;

    public decimal Calculate(decimal grossSalary)
    {
      return grossSalary * FGTSRate;
    }
  }
}
