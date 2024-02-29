using PayrollExtractGenerator.Application.DTOs;

namespace PayrollExtractGenerator.Application.Interfaces
{
  public interface IGeneratePayrollReportUseCase : IUseCase<long, PayrollExtractDTO>
  { }
}
