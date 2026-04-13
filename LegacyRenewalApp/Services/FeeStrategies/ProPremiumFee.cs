namespace LegacyRenewalApp.Services.FeeStrategies;

public class ProPremiumFee : IPremiumFeeStrategy
{
    public bool AppliesTo(string planCode) => planCode == "PRO";
    public decimal GetFee() => 400m;
}
