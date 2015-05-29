namespace MonopolyKata.PropertySquares
{
    public class GoSquare : Square
    {
        private Banker banker;

        public GoSquare(Banker banker) : base("Go")
        {
            this.banker = banker;
        }

        public override void IsLandedOn(Player player)
        {
            banker.GiveMoneyToPlayer(player, 200);
        }

        public override void IsPassedBy(Player player)
        {
            banker.GiveMoneyToPlayer(player, 200);
        }

    }
}
