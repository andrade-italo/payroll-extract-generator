namespace PayrollExtractGenerator.Application.Strategies
{
  public class DentalPlanCalculator : ICalculationStrategy
  {
    public decimal Calculate(decimal salary)
    {
      return 5m;
    }
  }
}
