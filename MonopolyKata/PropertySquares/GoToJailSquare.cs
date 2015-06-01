namespace MonopolyKata.PropertySquares
{
    public class GoToJailSquare : Square
    {
        private JailWarden warden;

        public GoToJailSquare(JailWarden warden) : base("Go To Jail")
        {
            this.warden = warden;
        }

        public override void IsLandedOn(Player player)
        {
            warden.MovePlayerToJail(player);
        }
    }
}
