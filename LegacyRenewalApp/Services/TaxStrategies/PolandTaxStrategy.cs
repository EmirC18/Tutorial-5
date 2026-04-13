namespace LegacyRenewalApp.Services.TaxStrategies;

public class PolandTaxStrategy : ITaxStrategy
{
    public bool AppliesTo(string country) => country == "Poland";
    public decimal GetTaxRate() => 0.23m;
}
