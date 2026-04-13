namespace LegacyRenewalApp.Services.DiscountStrategies;

public class LongTermLoyaltyDiscount : ILoyaltyDiscountStrategy
{
    public bool AppliesTo(int years) => years >= 5;
    public (decimal discount, string note) GetDiscount(decimal baseAmount) => (baseAmount * 0.07m, "long-term loyalty discount; ");
}
