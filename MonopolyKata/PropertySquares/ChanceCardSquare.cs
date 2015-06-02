using MonopolyKata.Cards;

namespace MonopolyKata.PropertySquares
{
    public class ChanceCardSquare : Square
    {
        private LazyLoadCardDealer dealer; 

        public ChanceCardSquare(LazyLoadCardDealer cardDealer) : base("Chance")
        {
            dealer = cardDealer;
        }

        public override void IsLandedOn(Player player)
        {
            Card card = dealer.DrawNextChanceCard();
            card.IsDrawn(player);
            if (card.GetType() == typeof (GetOutOfJailCard)) dealer.SetOwnerOfChanceJailCard(player);
            else dealer.AddCardToChancePile(card);
        }
    }
}
