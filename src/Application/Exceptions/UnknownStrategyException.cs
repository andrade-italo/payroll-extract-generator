namespace PayrollExtractGenerator.Application.Exceptions
{
  public class UnknownStrategyException : Exception
  {
    public UnknownStrategyException(string strategyName) : base($"Estratégia desconhecida: {strategyName}")
    { }
  }
}
