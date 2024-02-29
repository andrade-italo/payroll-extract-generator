namespace PayrollExtractGenerator.Application.Strategies
{
  public class TransportationVoucherCalculator : ICalculationStrategy
  {
    private const decimal MinimumSalaryForVoucher = 1500m;
    private const decimal VoucherRate = 0.06m;

    public decimal Calculate(decimal grossSalary)
    {
      if (grossSalary < MinimumSalaryForVoucher)
        return Decimal.Zero;
      else
        return grossSalary * VoucherRate;
    }
  }
}
