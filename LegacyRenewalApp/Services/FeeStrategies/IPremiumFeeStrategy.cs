namespace LegacyRenewalApp.Services.FeeStrategies;

public interface IPremiumFeeStrategy
{
    bool AppliesTo(string planCode);
    decimal GetFee();
}
