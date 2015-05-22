namespace MonopolyKata
{
    public class GoToJailSquare : Property
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
