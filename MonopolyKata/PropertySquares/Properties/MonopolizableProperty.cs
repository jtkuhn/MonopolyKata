using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata.PropertySquares.Properties
{
    public class MonopolizableProperty : Property
    {
        public Color Color;

        public MonopolizableProperty(IRentStrategy rentStrat, Banker banker, string nm, Realtor realtor, Color c, int cost = 0, int rent = 0) : base(rentStrat, banker, nm, realtor, cost: cost, rent: rent)
        {
            Color = c;
        }

        public override void IsLandedOn(Player player)
        {
            if (realtor.GetOwnerOf(this) != null)
            {
                ((RentStrategyMonopolizable)rentStrategy).SetRent(this);
                rentStrategy.GetMortgageStatus(IsMortgaged);
                int rent = rentStrategy.GetRent(realtor.GetOwnerOf(this), player);
                banker.TransferMoney(realtor.GetOwnerOf(this), player, rent);

            }
            else
            {
                player.Money -= cost;
                realtor.SetOwnerOf(this, player);
            }
        }
    }
}
