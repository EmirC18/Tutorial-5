namespace LegacyRenewalApp.Services.FeeStrategies;

public class CardPaymentFee : IPaymentFeeStrategy
{
    public bool AppliesTo(string method) => method == "CARD";
    public (decimal fee, string note) GetFee(decimal baseAmount) => (baseAmount * 0.02m, "card payment fee; ");
}
