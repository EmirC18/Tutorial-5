namespace LegacyRenewalApp.Services.FeeStrategies;

public interface IPaymentFeeStrategy
{
    bool AppliesTo(string method);
    (decimal fee, string note) GetFee(decimal baseAmount);
}
