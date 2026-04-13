namespace LegacyRenewalApp.Services.FeeStrategies;

public class StartPremiumFee : IPremiumFeeStrategy
{
    public bool AppliesTo(string planCode) => planCode == "START";
    public decimal GetFee() => 250m;
}
