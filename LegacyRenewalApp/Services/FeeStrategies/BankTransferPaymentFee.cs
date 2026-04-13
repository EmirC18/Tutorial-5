namespace LegacyRenewalApp.Services.FeeStrategies;

public class BankTransferPaymentFee : IPaymentFeeStrategy
{
    public bool AppliesTo(string method) => method == "BANK_TRANSFER";
    public (decimal fee, string note) GetFee(decimal baseAmount) => (baseAmount * 0.01m, "bank transfer fee; ");
}
