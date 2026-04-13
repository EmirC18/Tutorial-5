namespace LegacyRenewalApp.Services.FeeStrategies;

public class InvoicePaymentFee : IPaymentFeeStrategy
{
    public bool AppliesTo(string method) => method == "INVOICE";
    public (decimal fee, string note) GetFee(decimal baseAmount) => (0m, "invoice payment; ");
}
