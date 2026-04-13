namespace LegacyRenewalApp.Services;

public class EmailService
{
    private readonly IBillingGateway _billingGateway;

    public EmailService(IBillingGateway billingGateway)
    {
        _billingGateway = billingGateway;
    }

    public void SendEmailToCustomer(Customer customer,string normalizedPlanCode,RenewalInvoice invoice)
    {
        if (!string.IsNullOrWhiteSpace(customer.Email))
        {
            string subject = "Subscription renewal invoice";
            string body =
                $"Hello {customer.FullName}, your renewal for plan {normalizedPlanCode} " +
                $"has been prepared. Final amount: {invoice.FinalAmount:F2}.";

            _billingGateway.SendEmail(customer.Email, subject, body);
        }
    }
}