namespace LegacyRenewalApp.Services.DiscountStrategies;

public class BasicLoyaltyDiscount : ILoyaltyDiscountStrategy
{
    public bool AppliesTo(int years) => years >= 2;
    public (decimal discount, string note) GetDiscount(decimal baseAmount) => (baseAmount * 0.03m, "basic loyalty discount; ");
}
