using Microsoft.AspNetCore.Mvc;
using PayrollExtractGenerator.Application.Interfaces;
using PayrollExtractGenerator.Domain.Exceptions;
using PayrollExtractGenerator.Api.Models;
using PayrollExtractGenerator.Api.Mappers;

namespace PayrollExtractGenerator.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : ControllerBase
  {
    private readonly IGetEmployeeByIdUseCase _getEmployeeByIdUseCase;
    private readonly ICreateEmployeeUseCase _createEmployeeUseCase;

    public EmployeeController(IGetEmployeeByIdUseCase getEmployeeByIdUseCase, ICreateEmployeeUseCase createEmployeeUseCase)
    {
      _getEmployeeByIdUseCase = getEmployeeByIdUseCase;
      _createEmployeeUseCase = createEmployeeUseCase;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(long id)
    {
      try
      {
        var employee = await _getEmployeeByIdUseCase.ExecuteAsync(id);
        return Ok(employee);
      }
      catch (EmployeeNotFoundException ex)
      {
        return NotFound(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest request)
    {
      try
      {
        var employeeDto = request.MapToDTO();
        var employeeCreated = await _createEmployeeUseCase.ExecuteAsync(employeeDto);

        return CreatedAtAction(nameof(CreateEmployee), employeeCreated);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
