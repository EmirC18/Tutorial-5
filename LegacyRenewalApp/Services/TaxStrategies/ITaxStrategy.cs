namespace LegacyRenewalApp.Services.TaxStrategies;

public interface ITaxStrategy
{
    bool AppliesTo(string country);
    decimal GetTaxRate();
}