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
      if (salary > FourthThreshold)
      {
        return (salary * FourthRate) - FourthDeduction;
      }

      else if (salary > ThirdThreshold && salary <= FourthThreshold)
      {
        return (salary * ThirdRate) - ThirdDeduction;

      }
      else if (salary > SecondThreshold && salary <= ThirdThreshold)
      {
        return (salary * SecondRate) - SecondDeduction;

      }
      else if (salary > FirstThreshold && salary <= SecondThreshold)
      {
        return (salary * FirstRate) - FirstDeduction;

      }
      else
      {
        return Decimal.Zero;
      }
    }
  }
}
