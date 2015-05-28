using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata.PropertySquares.Properties
{
    public class MonopolizableProperty : Property
    {
        public Color Color;

        public MonopolizableProperty(IRentStrategy rentStrat, string nm, Realtor realtor, Color c, int cost = 0, int rent = 0) : base(rentStrat, nm, realtor, cost: cost, rent: rent)
        {
            Color = c;
        }

        public override void IsLandedOn(Player player)
        {
            if (realtor.GetOwnerOf(this) != null)
            {
                ((RentStrategyMonopolizable)rentStrategy).SetRent(this);
                rentStrategy.GetMortgageStatus(IsMortgaged);
                rentStrategy.GetRent(realtor.GetOwnerOf(this), player);
            }
            else
            {
                player.Money -= cost;
                realtor.SetOwnerOf(this, player);
            }
        }
    }
}
