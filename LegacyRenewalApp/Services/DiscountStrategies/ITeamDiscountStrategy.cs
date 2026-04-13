namespace LegacyRenewalApp.Services.DiscountStrategies;

public interface ITeamDiscountStrategy
{
    bool AppliesTo(int seatCount);
    (decimal discount, string note) GetDiscount(decimal baseAmount);
}
