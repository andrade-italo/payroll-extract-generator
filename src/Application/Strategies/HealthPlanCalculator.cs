namespace PayrollExtractGenerator.Application.Strategies
{
  public class HealthPlanCalculator : ICalculationStrategy
  {
    private const decimal HealthPlanAmount = 10m;

    public decimal Calculate(decimal salary)
    {
      return HealthPlanAmount;
    }
  }
}
