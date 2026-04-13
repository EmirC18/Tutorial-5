namespace LegacyRenewalApp.Services.DiscountStrategies;

public class GoldSegmentDiscount : ISegmentDiscountStrategy
{
    public bool AppliesTo(string segment, bool isEducationEligible) => segment == "Gold";
    public (decimal discount, string note) GetDiscount(decimal baseAmount) => (baseAmount * 0.10m, "gold discount; ");
}
