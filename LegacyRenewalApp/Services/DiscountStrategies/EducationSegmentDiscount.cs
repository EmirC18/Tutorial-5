namespace LegacyRenewalApp.Services.DiscountStrategies;

public class EducationSegmentDiscount : ISegmentDiscountStrategy
{
    public bool AppliesTo(string segment, bool isEducationEligible) => segment == "Education" && isEducationEligible;
    public (decimal discount, string note) GetDiscount(decimal baseAmount) => (baseAmount * 0.20m, "education discount; ");
}
