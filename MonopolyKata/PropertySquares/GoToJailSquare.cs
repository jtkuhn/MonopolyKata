namespace MonopolyKata.PropertySquares
{
    public class GoToJailSquare : Square
    {
        public GoToJailSquare() : base("GoToJail")
        {
        }

        public override void IsLandedOn(Player player)
        {
            player.Position = 10;
        }
    }
}
