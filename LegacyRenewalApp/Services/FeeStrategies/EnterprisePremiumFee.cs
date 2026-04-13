namespace LegacyRenewalApp.Services.FeeStrategies;

public class EnterprisePremiumFee : IPremiumFeeStrategy
{
    public bool AppliesTo(string planCode) => planCode == "ENTERPRISE";
    public decimal GetFee() => 700m;
}
