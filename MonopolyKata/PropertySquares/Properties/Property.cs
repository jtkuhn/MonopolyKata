using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata.PropertySquares
{
    public class Property : Square
    {
        public Player owner;
        public int cost;
        public int rent;
        protected readonly IRentStrategy rentStrategy;

        public bool IsMortgaged { get; set; }

        public Property(IRentStrategy rentStrat, string nm, int cost = 0, int rent = 0) : base(nm)
        {
            IsMortgaged = false;
            rentStrategy = rentStrat;
            this.cost = cost;
            this.rent = rent;
        }

        public void SetOwner(Player player)
        {
            owner = player;
        }

        public override void IsLandedOn(Player player)
        {
            if (owner != null)
            {
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
