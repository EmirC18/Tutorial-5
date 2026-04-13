namespace LegacyRenewalApp.Services.DiscountStrategies;

public class MediumTeamDiscount : ITeamDiscountStrategy
{
    public bool AppliesTo(int seatCount) => seatCount >= 20;
    public (decimal discount, string note) GetDiscount(decimal baseAmount) => (baseAmount * 0.08m, "medium team discount; ");
}
