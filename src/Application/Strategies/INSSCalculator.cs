namespace PayrollExtractGenerator.Application.Strategies
{
  public class INSSCalculator : ICalculationStrategy
  {
    private const decimal FirstThreshold = 1045m;
    private const decimal SecondThreshold = 2089.6m;
    private const decimal ThirdThreshold = 3134.4m;
    private const decimal FirstRate = 0.075m;
    private const decimal SecondRate = 0.09m;
    private const decimal ThirdRate = 0.12m;
    private const decimal FourthRate = 0.14m;

    public decimal Calculate(decimal grossSalary)
    {
      if (grossSalary <= FirstThreshold)
        return grossSalary * FirstRate;
      else if (grossSalary <= SecondThreshold)
        return grossSalary * SecondRate;
      else if (grossSalary <= ThirdThreshold)
        return grossSalary * ThirdRate;
      else
        return grossSalary * FourthRate;
    }
  }
}
