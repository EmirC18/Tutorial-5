namespace LegacyRenewalApp.Services.TaxStrategies;

public class CzechRepublicTaxStrategy : ITaxStrategy
{
    public bool AppliesTo(string country) => country == "Czech Republic";
    public decimal GetTaxRate() => 0.21m;
}
