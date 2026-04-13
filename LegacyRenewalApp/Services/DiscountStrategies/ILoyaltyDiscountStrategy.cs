namespace LegacyRenewalApp.Services.DiscountStrategies;

public interface ILoyaltyDiscountStrategy
{
    bool AppliesTo(int years);
    (decimal discount, string note) GetDiscount(decimal baseAmount);
}
