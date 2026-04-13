namespace LegacyRenewalApp.Services.DiscountStrategies;

public class PlatinumSegmentDiscount : ISegmentDiscountStrategy
{
    public bool AppliesTo(string segment, bool isEducationEligible) => segment == "Platinum";
    public (decimal discount, string note) GetDiscount(decimal baseAmount) => (baseAmount * 0.15m, "platinum discount; ");
}
