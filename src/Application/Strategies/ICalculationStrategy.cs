namespace PayrollExtractGenerator.Application.Strategies
{
  public interface ICalculationStrategy
  {
    decimal Calculate(decimal salary);
  }
}
