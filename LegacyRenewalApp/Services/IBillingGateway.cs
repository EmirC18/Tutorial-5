namespace LegacyRenewalApp.Services;

public interface IBillingGateway
{
    void SendEmail(string email, string subject, string body);
    void SaveInvoice(RenewalInvoice invoice);
}
