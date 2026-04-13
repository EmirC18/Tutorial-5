using System.Collections.Generic;
using System.Linq;
using LegacyRenewalApp.Services.DiscountStrategies;

namespace LegacyRenewalApp.Services;

public class DiscountService
{
    private readonly List<ISegmentDiscountStrategy> _segmentStrategies = new()
    {
        new SilverSegmentDiscount(),
        new GoldSegmentDiscount(),
        new PlatinumSegmentDiscount(),
        new EducationSegmentDiscount()
    };

    private readonly List<ILoyaltyDiscountStrategy> _loyaltyStrategies = new()
    {
        new LongTermLoyaltyDiscount(),
        new BasicLoyaltyDiscount()
    };

    private readonly List<ITeamDiscountStrategy> _teamStrategies = new()
    {
        new LargeTeamDiscount(),
        new MediumTeamDiscount(),
        new SmallTeamDiscount()
    };

    public (decimal discountAmount,string notes) ReturnSegment(Customer customer,SubscriptionPlan plan,int seatCount,decimal baseAmount)
    {
        var strategy = _segmentStrategies.FirstOrDefault(s => s.AppliesTo(customer.Segment, plan.IsEducationEligible));
        if (strategy != null)
        {
            return strategy.GetDiscount(baseAmount);
        }
        return (0m, string.Empty);
    }

    public (decimal discountAmount, string notes) returnLoyaltyDis(Customer customer, decimal discountAmount, string notes,decimal baseAmount)
    {
        var strategy = _loyaltyStrategies.FirstOrDefault(s => s.AppliesTo(customer.YearsWithCompany));
        if (strategy != null)
        {
            var (disc, note) = strategy.GetDiscount(baseAmount);
            return (discountAmount + disc, notes + note);
        }
        return (discountAmount, notes);
    }

    public (decimal discountAmount, string notes) returnTeamDiscount(Customer customer, decimal discountAmount, string notes, decimal baseAmount,int seatCount) {
        var strategy = _teamStrategies.FirstOrDefault(s => s.AppliesTo(seatCount));
        if (strategy != null)
        {
            var (disc, note) = strategy.GetDiscount(baseAmount);
            return (discountAmount + disc, notes + note);
        }
        return (discountAmount, notes);
    }

    public (decimal discountAmount, string notes) spendLoyaltyDis(Customer customer, decimal discountAmount, bool useLoyaltyPoints, string notes){
        if (useLoyaltyPoints && customer.LoyaltyPoints > 0)
        {
            int pointsToUse = customer.LoyaltyPoints > 200 ? 200 : customer.LoyaltyPoints;
            discountAmount += pointsToUse;
            notes += $"loyalty points used: {pointsToUse}; ";
        }
        return (discountAmount, notes);
    }

    public (decimal subtotalAfterDiscount, string notes) returnSubtotalAfterDis(string notes, decimal subtotalAfterDiscount){
        
        if (subtotalAfterDiscount < 300m)
        {
            subtotalAfterDiscount = 300m;
            notes += "minimum discounted subtotal applied; ";
        }
        return (subtotalAfterDiscount, notes);
    }
}