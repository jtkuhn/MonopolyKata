namespace MonopolyKata
{
    public class GoSquare : Property
    {
        public GoSquare() : base("Go")
        {
        }


        public override void IsLandedOn(Player player)
        {
            player.Money += 200;
        }

        public override void IsPassedBy(Player player)
        {
            player.Money += 200;
        }

    }
}
