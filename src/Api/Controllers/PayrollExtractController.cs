using Microsoft.AspNetCore.Mvc;
using PayrollExtractGenerator.Application.Interfaces;
using PayrollExtractGenerator.Domain.Exceptions;

namespace PayrollExtractGenerator.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PayrollExtractController : ControllerBase
  {
    private readonly IGeneratePayrollReportUseCase _generatePayrollReportUseCase;

    public PayrollExtractController(IGeneratePayrollReportUseCase generatePayrollReportUseCase)
    {
      _generatePayrollReportUseCase = generatePayrollReportUseCase;
    }

    [HttpGet("extract/{employeeId}")]
    public async Task<IActionResult> GetPayrollReport(long employeeId)
    {
      try
      {
        var payrollReport = await _generatePayrollReportUseCase.ExecuteAsync(employeeId);
        return Ok(payrollReport);
      }
      catch (EmployeeNotFoundException ex)
      {
        return NotFound(ex.Message);
      }
    }
  }
}
