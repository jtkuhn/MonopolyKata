namespace MonopolyKata.PropertySquares
{
    public class IncomeTaxSquare : Square
    {
        public IncomeTaxSquare() : base("Income Tax")
        {
        }

        public override void IsLandedOn(Player player)
        {
            if (player.Money < 2000) player.Money -= player.Money/10;
            else player.Money -= 200;
        }
    }
}
