namespace LegacyRenewalApp.Services.DiscountStrategies;

public class SmallTeamDiscount : ITeamDiscountStrategy
{
    public bool AppliesTo(int seatCount) => seatCount >= 10;
    public (decimal discount, string note) GetDiscount(decimal baseAmount) => (baseAmount * 0.04m, "small team discount; ");
}
