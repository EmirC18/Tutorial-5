namespace LegacyRenewalApp.Services.TaxStrategies;

public class NorwayTaxStrategy : ITaxStrategy
{
    public bool AppliesTo(string country) => country == "Norway";
    public decimal GetTaxRate() => 0.25m;
}
