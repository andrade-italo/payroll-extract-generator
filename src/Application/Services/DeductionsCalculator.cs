using PayrollExtractGenerator.Application.Strategies;
using PayrollExtractGenerator.Domain.Enums;
using PayrollExtractGenerator.Application.Exceptions;
using PayrollExtractGenerator.Domain.ValueObjects;

namespace PayrollExtractGenerator.Application.Services
{
  public class DeductionsCalculator
  {
    private readonly List<ICalculationStrategy> _strategies;

    public List<Deductions> CalculateAll(decimal salary)
    {
      var deductionsList = new List<Deductions>();

      foreach (var strategy in _strategies)
      {
        var deductionsType = strategy switch
        {
          INSSCalculator => DeductionsType.INSS,
          IncomeTaxCalculator => DeductionsType.IncomeTax,
          HealthPlanCalculator => DeductionsType.HealthPlan,
          DentalPlanCalculator => DeductionsType.DentalPlan,
          TransportationVoucherCalculator => DeductionsType.TransportationVoucher,
          FGTSCalculator => DeductionsType.FGTS,
          _ => throw new UnknownStrategyException(strategy.GetType().Name),
        };
        var deductionsValue = strategy.Calculate(salary);
        var deductionEntry = new Deductions(EntriesItemType.Deduction, deductionsValue, deductionsType);
        deductionsList.Add(deductionEntry);
      }

      return deductionsList;
    }
  }
}
