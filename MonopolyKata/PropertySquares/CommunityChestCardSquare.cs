using MonopolyKata.Cards;

namespace MonopolyKata.PropertySquares
{
    public class CommunityChestCardSquare : Square
    {
        private LazyLoadCardDealer dealer;

        public CommunityChestCardSquare(LazyLoadCardDealer cardDealer) : base("Community Chest")
        {
            dealer = cardDealer;
        }

        public override void IsLandedOn(Player player)
        {
            Card card = dealer.DrawNextCommunityChestCard();
            card.IsDrawn(player);
            if (card.GetType() == typeof(GetOutOfJailCard)) dealer.SetOwnerOfCommunityChestJailCard(player);
            else dealer.AddCardToCommunityChestPile(card);
        }
    }
}
