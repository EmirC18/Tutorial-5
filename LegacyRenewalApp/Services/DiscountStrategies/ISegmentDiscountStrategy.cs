namespace LegacyRenewalApp.Services.DiscountStrategies;

public interface ISegmentDiscountStrategy
{
    bool AppliesTo(string segment, bool isEducationEligible);
    (decimal discount, string note) GetDiscount(decimal baseAmount);
}
