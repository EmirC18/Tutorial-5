using System;
using System.Collections.Generic;
using System.Linq;
using LegacyRenewalApp.Services.FeeStrategies;

namespace LegacyRenewalApp.Services;

public class ExtraFeeService
{
    private readonly List<IPremiumFeeStrategy> _premiumStrategies = new()
    {
        new StartPremiumFee(),
        new ProPremiumFee(),
        new EnterprisePremiumFee()
    };

    private readonly List<IPaymentFeeStrategy> _paymentStrategies = new()
    {
        new CardPaymentFee(),
        new BankTransferPaymentFee(),
        new PaypalPaymentFee(),
        new InvoicePaymentFee()
    };

    public (decimal supportFee, string notes) IncludePremium(decimal supportFee, bool includePremiumSupport,
        string normalizedPlanCode, string notes)
    {
        if (includePremiumSupport)
        {
            var strategy = _premiumStrategies.FirstOrDefault(s => s.AppliesTo(normalizedPlanCode));
            if (strategy != null)
            {
                supportFee = strategy.GetFee();
                notes += "premium support included; ";
            }
        }
        return (supportFee, notes);
    }

    public (decimal paymentFee,string notes) PaymentMethodFee(string normalizedPaymentMethod
        ,decimal paymentFee,decimal subtotalAfterDiscount ,decimal supportFee,string notes)
    {
        var strategy = _paymentStrategies.FirstOrDefault(s => s.AppliesTo(normalizedPaymentMethod));
        if (strategy != null)
        {
            return strategy.GetFee(subtotalAfterDiscount + supportFee);
        }
        throw new ArgumentException("Unsupported payment method");
    }
}