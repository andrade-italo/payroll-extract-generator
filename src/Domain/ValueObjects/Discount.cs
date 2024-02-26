using PayrollExtractGenerator.Domain.Enums;

namespace PayrollExtractGenerator.Domain.ValueObjects
{
  public record Discount(DiscountType Type, decimal Value);
};
