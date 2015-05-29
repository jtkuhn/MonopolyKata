namespace MonopolyKata.PropertySquares
{
    public class LuxuryTaxSquare : Square
    {
        private Banker banker;

        public LuxuryTaxSquare(Banker banker) : base("Luxury Tax")
        {
            this.banker = banker;
        }

        public override void IsLandedOn(Player player)
        {
            banker.TakeMoneyFromPlayer(player, 75);
        }
    }
}
