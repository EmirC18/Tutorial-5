using System;
using LegacyRenewalApp.Services;

namespace LegacyRenewalApp
{
    public class SubscriptionRenewalService
    {
        //services:
        private InputValidationService inputVal = new();
        private LoadRepositoryService _lRepositoryService = new();
        private DiscountService discountServ = new();
        private ExtraFeeService extraFeeServ = new();
        private TaxService taxServ = new();
        private InvoiceService _invoiceServ;
        private EmailService emailServ;

        public SubscriptionRenewalService()
        {
            var billingGateway = new LegacyBillingGatewayAdapter();
            _invoiceServ = new InvoiceService(billingGateway);
            emailServ = new EmailService(billingGateway);
        }

        public RenewalInvoice CreateRenewalInvoice(
            int customerId,
            string planCode,
            int seatCount,
            string paymentMethod,
            bool includePremiumSupport,
            bool useLoyaltyPoints)
        {
            inputVal.ValidateInput(customerId, planCode, seatCount, paymentMethod);

            string normalizedPlanCode = planCode.Trim().ToUpperInvariant();
            string normalizedPaymentMethod = paymentMethod.Trim().ToUpperInvariant();

            var (customer, plan) = _lRepositoryService.SendRepository(normalizedPlanCode, customerId);


            //Discount Services:
            //Segment
            decimal baseAmount = (plan.MonthlyPricePerSeat * seatCount * 12m) + plan.SetupFee;
            var (discountAmount, notes) = discountServ.ReturnSegment(customer, plan, seatCount, baseAmount);

            //Loyalty discount
            (discountAmount, notes) = discountServ.returnLoyaltyDis(customer, discountAmount, notes, baseAmount);

            //Team discount
            (discountAmount, notes) = discountServ.returnTeamDiscount(customer, discountAmount, notes, baseAmount, seatCount);

            //Spend Loyalty Discount
            (discountAmount, notes) = discountServ.spendLoyaltyDis(customer, discountAmount, useLoyaltyPoints, notes);

            //Subtotal After Discount
            decimal subtotalAfterDiscount = baseAmount - discountAmount;
            (subtotalAfterDiscount, notes) = discountServ.returnSubtotalAfterDis(notes, subtotalAfterDiscount);


            //Fee services:
            //Include Premium service
            decimal supportFee = 0m;
            (supportFee, notes) =
                extraFeeServ.IncludePremium(supportFee, includePremiumSupport, normalizedPlanCode, notes);

            //Payment Method Fee
            decimal paymentFee = 0m;
            (paymentFee, notes) = extraFeeServ.PaymentMethodFee(normalizedPaymentMethod, paymentFee,
                subtotalAfterDiscount, supportFee, notes);

            //Tax Service
            decimal taxRate = 0.20m;
            taxRate = taxServ.CheckTaxRate(customer, taxRate);

            decimal taxBase = subtotalAfterDiscount + supportFee + paymentFee;
            decimal taxAmount = taxBase * taxRate;
            decimal finalAmount = taxBase + taxAmount;

            //minimize final tax
            (finalAmount, notes) = taxServ.FinalTaxAmount(finalAmount, notes);

            //Invoice service:
            var invoice = _invoiceServ.CreateAndSaveCreateInvoice(
                customer, customerId, normalizedPlanCode,
                normalizedPaymentMethod, seatCount, baseAmount, discountAmount,
                supportFee, paymentFee, taxAmount, finalAmount, notes
            );

            //Email service:
            emailServ.SendEmailToCustomer(customer, normalizedPlanCode, invoice);

            return invoice;
        }
    }
}