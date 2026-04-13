namespace LegacyRenewalApp.Services.DiscountStrategies;

public class SilverSegmentDiscount : ISegmentDiscountStrategy
{
    public bool AppliesTo(string segment, bool isEducationEligible) => segment == "Silver";
    public (decimal discount, string note) GetDiscount(decimal baseAmount) => (baseAmount * 0.05m, "silver discount; ");
}
