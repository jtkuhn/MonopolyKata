using MonopolyKata.Cards;

namespace MonopolyKata.PropertySquares
{
    public class ChanceCardSquare : Square
    {
        private CardDealer dealer; 
        public ChanceCardSquare(CardDealer cardDealer) : base("Chance")
        {
            dealer = cardDealer;
        }

        public override void IsLandedOn(Player player)
        {
            Card card = dealer.DrawNextChanceCard();
            card.IsDrawn(player);
            dealer.AddCardToChancePile(card);
        }
    }
}
