namespace MonopolyKata.PropertySquares
{
    public class IncomeTaxSquare : Square
    {
        private Banker banker;

        public IncomeTaxSquare(Banker banker) : base("Income Tax")
        {
            this.banker = banker;
        }

        public override void IsLandedOn(Player player)
        {
            if (player.Money < 2000) banker.TakeMoneyFromPlayer(player, player.Money/10);
            else banker.TakeMoneyFromPlayer(player, 200);
        }
    }
}
