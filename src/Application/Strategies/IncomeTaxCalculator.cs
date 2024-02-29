namespace PayrollExtractGenerator.Application.Strategies
{
  public class IncomeTaxCalculator : ICalculationStrategy
  {
    private const decimal FirstThreshold = 1903.98m;
    private const decimal SecondThreshold = 2826.65m;
    private const decimal ThirdThreshold = 3751.05m;
    private const decimal FourthThreshold = 4664.68m;

    private const decimal FirstRate = 0.075m;
    private const decimal SecondRate = 0.15m;
    private const decimal ThirdRate = 0.225m;
    private const decimal FourthRate = 0.275m;

    private const decimal FirstDeduction = 142.8m;
    private const decimal SecondDeduction = 354.8m;
    private const decimal ThirdDeduction = 636.13m;
    private const decimal FourthDeduction = 869.36m;

    public decimal Calculate(decimal salary)
    {
      ITaxCalculationStrategy _strategy = salary switch
      {
        <= FirstThreshold => new ProgressiveTaxCalculationStrategy(salary, Decimal.Zero, Decimal.Zero),
        <= SecondThreshold => new ProgressiveTaxCalculationStrategy(salary, FirstRate, FirstDeduction),
        <= ThirdThreshold => new ProgressiveTaxCalculationStrategy(salary, SecondRate, SecondDeduction),
        <= FourthThreshold => new ProgressiveTaxCalculationStrategy(salary, ThirdRate, ThirdDeduction),
        _ => new ProgressiveTaxCalculationStrategy(salary, FourthRate, FourthDeduction)
      };

      return _strategy.Calculate();
    }
  }
}
