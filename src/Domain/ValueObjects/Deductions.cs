using PayrollExtractGenerator.Domain.Enums;

namespace PayrollExtractGenerator.Domain.ValueObjects
{
  public record Deductions(string type, decimal Value, string description);
};
