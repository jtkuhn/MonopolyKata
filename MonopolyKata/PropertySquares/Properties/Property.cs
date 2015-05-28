using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata.PropertySquares
{
    public class Property : Square
    {
        public int cost;
        public int rent;
        protected readonly IRentStrategy rentStrategy;
        protected Realtor realtor;

        public bool IsMortgaged { get; set; }

        public Property(IRentStrategy rentStrat, string nm, Realtor realtor, int cost = 0, int rent = 0) : base(nm)
        {
            this.realtor = realtor;
            IsMortgaged = false;
            rentStrategy = rentStrat;
            this.cost = cost;
            this.rent = rent;
        }

        public override void IsLandedOn(Player player)
        {
            if (realtor.GetOwnerOf(this) != null)
            {
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
