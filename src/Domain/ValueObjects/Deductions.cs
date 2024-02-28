using PayrollExtractGenerator.Domain.Enums;

namespace PayrollExtractGenerator.Domain.ValueObjects
{
  public record Deductions(EntriesItemType type, decimal Value, DeductionsType description);
};
