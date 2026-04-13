namespace LegacyRenewalApp.Services.TaxStrategies;

public class GermanyTaxStrategy : ITaxStrategy
{
    public bool AppliesTo(string country) => country == "Germany";
    public decimal GetTaxRate() => 0.19m;
}
