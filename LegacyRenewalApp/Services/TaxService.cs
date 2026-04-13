using System.Collections.Generic;
using System.Linq;
using LegacyRenewalApp.Services.TaxStrategies;

namespace LegacyRenewalApp.Services;

public class TaxService
{
    private readonly List<ITaxStrategy> _strategies = new()
    {
        new PolandTaxStrategy(),
        new GermanyTaxStrategy(),
        new CzechRepublicTaxStrategy(),
        new NorwayTaxStrategy()
    };

    public decimal CheckTaxRate(Customer customer, decimal taxRate)
    {
        var strategy = _strategies.FirstOrDefault(s => s.AppliesTo(customer.Country));
        return strategy != null ? strategy.GetTaxRate() : taxRate;
    }

    public (decimal finalAmount, string notes) FinalTaxAmount(decimal finalAmount, string notes)
    {
        if (finalAmount < 500m)
        {
            finalAmount = 500m;
            notes += "minimum invoice amount applied; ";
        }
        return (finalAmount, notes);
    }
}