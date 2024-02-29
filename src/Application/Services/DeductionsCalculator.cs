using PayrollExtractGenerator.Application.Strategies;
using PayrollExtractGenerator.Domain.Enums;
using PayrollExtractGenerator.Application.Exceptions;
using PayrollExtractGenerator.Domain.ValueObjects;

namespace PayrollExtractGenerator.Application.Services
{
  public class DeductionsCalculator
  {
    public List<Deductions> CalculateAll(decimal salary)
    {
      var deductionsList = new List<Deductions>();

      foreach (DeductionsType deductionsType in Enum.GetValues(typeof(DeductionsType)))
      {
        ICalculationStrategy strategy = deductionsType switch
        {
          DeductionsType.INSS => new INSSCalculator(),
          DeductionsType.IncomeTax => new IncomeTaxCalculator(),
          DeductionsType.HealthPlan => new HealthPlanCalculator(),
          DeductionsType.DentalPlan => new DentalPlanCalculator(),
          DeductionsType.TransportationVoucher => new TransportationVoucherCalculator(),
          DeductionsType.FGTS => new FGTSCalculator(),
          _ => throw new UnknownStrategyException(deductionsType.ToString()),
        };

        var deductionsValue = strategy.Calculate(salary);
        var deductionEntry = new Deductions(EntriesItemType.Deduction.ToString(), deductionsValue, deductionsType.ToString());
        deductionsList.Add(deductionEntry);
      }

      return deductionsList;
    }
  }
}
