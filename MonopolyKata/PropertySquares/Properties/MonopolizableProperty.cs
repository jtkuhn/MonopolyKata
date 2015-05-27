using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata.PropertySquares.Properties
{
    public class MonopolizableProperty : Property
    {
        public MonopolizableProperty(IRentStrategy rentStrat, string nm, int cost = 0, int rent = 0) : base(rentStrat, nm, cost, rent)
        {
        }

        public override void IsLandedOn(Player player)
        {
            if (owner != null)
            {
                ((RentStrategyMonopolizable)rentStrategy).SetRent(this);
                rentStrategy.GetMortgageStatus(IsMortgaged);
                rentStrategy.GetRent(owner, player);
            }
            else
            {
                player.Money -= cost;
                owner = player;
            }
        }
    }
}
