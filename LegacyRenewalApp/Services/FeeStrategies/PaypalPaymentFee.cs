namespace LegacyRenewalApp.Services.FeeStrategies;

public class PaypalPaymentFee : IPaymentFeeStrategy
{
    public bool AppliesTo(string method) => method == "PAYPAL";
    public (decimal fee, string note) GetFee(decimal baseAmount) => (baseAmount * 0.035m, "paypal fee; ");
}
