namespace LegacyRenewalApp.Services;

public class LegacyBillingGatewayAdapter : IBillingGateway
{
    public void SendEmail(string email, string subject, string body)
    {
        LegacyBillingGateway.SendEmail(email, subject, body);
    }

    public void SaveInvoice(RenewalInvoice invoice)
    {
        LegacyBillingGateway.SaveInvoice(invoice);
    }
}
