namespace MonopolyKata.PropertySquares
{
    public class LuxuryTaxSquare : Square
    {
        public LuxuryTaxSquare() : base("Luxury Tax")
        {
        }

        public override void IsLandedOn(Player player)
        {
            player.Money -= 75;
        }
    }
}
