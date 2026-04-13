namespace LegacyRenewalApp.Services.DiscountStrategies;

public class LargeTeamDiscount : ITeamDiscountStrategy
{
    public bool AppliesTo(int seatCount) => seatCount >= 50;
    public (decimal discount, string note) GetDiscount(decimal baseAmount) => (baseAmount * 0.12m, "large team discount; ");
}
