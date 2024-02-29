using Moq;
using AutoFixture;
using FluentAssertions;
using PayrollExtractGenerator.Application.UseCases;
using PayrollExtractGenerator.Application.Mappers;
using PayrollExtractGenerator.Domain.Interfaces;
using PayrollExtractGenerator.Domain.Exceptions;
using PayrollExtractGenerator.Domain.Entities;
using Moq.AutoMock;

namespace PayrollExtractGenerator.Application.Tests.UseCases
{
  public class GetEmployeeByIdUseCaseTests
  {
    private readonly GetEmployeeByIdUseCase _sut;
    private readonly Mock<IEmployeeRepository> _repositoryMock;
    private readonly IFixture _autoFixture;

    public GetEmployeeByIdUseCaseTests()
    {
      _autoFixture = new Fixture();
      var autoMocker = new AutoMocker();

      _repositoryMock = autoMocker.GetMock<IEmployeeRepository>();

      _sut = autoMocker.CreateInstance<GetEmployeeByIdUseCase>();
    }


    [Fact(DisplayName = "GetEmployeeByIdUseCase with existing employee should return EmployeeDTO")]
    public async Task GetEmployeeByIdUseCase_WithExistingEmployee_ShouldReturnEmployeeDTO()
    {
      // Arrange
      var employeeId = _autoFixture.Create<long>();
      var employee = _autoFixture.Create<Employee>();
      _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<long>()))
        .ReturnsAsync(employee);

      // Act
      var result = await _sut.ExecuteAsync(employeeId);


      // Assert
      result.Should().NotBeNull();
      result.Should().BeEquivalentTo(employee.MapToDto());

      _repositoryMock.Verify(repo => repo.GetByIdAsync(employeeId), Times.Once);
    }

    [Fact(DisplayName = "GetEmployeeByIdUseCase with non-existing employee should throw EmployeeNotFoundException")]
    public async Task GetEmployeeByIdUseCase_WithNonExistingEmployee_ShouldThrowEmployeeNotFoundException()
    {
      // Arrange
      var employeeId = _autoFixture.Create<long>();
      _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<long>()))
                            .ReturnsAsync((Employee)null);

      // Act
      Func<Task> action = async () => await _sut.ExecuteAsync(employeeId);


      // Assert
      await action.Should().ThrowAsync<EmployeeNotFoundException>();

      _repositoryMock.Verify(repo => repo.GetByIdAsync(employeeId), Times.Once);
    }
  }
}
