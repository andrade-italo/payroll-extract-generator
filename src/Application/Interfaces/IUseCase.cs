namespace PayrollExtractGenerator.Application.Interfaces
{
  public interface IUseCase<in TInput, TOutput>
  {
    Task<TOutput> ExecuteAsync(TInput request);
  }
}
