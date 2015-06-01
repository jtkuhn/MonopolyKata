using MonopolyKata;
using MonopolyKata.Cards;
using MonopolyKata.PropertySquares.Rent;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class CardDealerTest
    {
        private CardDealer dealer;
        private Banker banker;
        private Realtor realtor;
        private JailWarden jailWarden;
        private Board board;

        [SetUp]
        public void Setup()
        {
            banker = new Banker();
            jailWarden = new JailWarden();
            board = new Board(realtor, jailWarden, banker, new DiceRoller());
            dealer = new CardDealer(banker, jailWarden, board);
        }

        [Test]
        public void InitializingADealer_CreatesCardsToUse()
        {
            Assert.NotNull(dealer.DrawNextChanceCard()); 
            Assert.NotNull(dealer.DrawNextCommunityChestCard());
        }

        [Test]
        public void PullingACardOffThePile_DecrementsThePileSize()
        {
            int initialNumberOfCards = dealer.chanceSize;

            dealer.DrawNextChanceCard();
            Assert.AreEqual(initialNumberOfCards - 1, dealer.chanceSize);
        }

        [Test]
        public void PuttingACardOnThePile_IncrementsTheSize()
        {
            int initialNumberOfCards = dealer.chanceSize;

            dealer.AddCardToChancePile(new Card("Hi"));;
            Assert.AreEqual(initialNumberOfCards + 1, dealer.chanceSize);
        }

        [Test]
        public void PlayerThatGetsAGetOutOfJailFreeCard_OwnsAGetOutOfJailCard()
        {
            Player player1 = new Player("Bob");

            Assert.False(dealer.OwnsAGetOutOfJailCard(player1));
            dealer.SetOwnerOfChanceJailCard(player1);
            //Assert.True(dealer.OwnsAGetOutOfJailCard(player1));
        }

        [Test]
        public void PlayerThatUsesAGetOutOfJailCard_LosesAGetOutOfJailCard()
        {
            Player player1 = new Player("Bill");

            Assert.False(dealer.OwnsAGetOutOfJailCard(player1));
            dealer.SetOwnerOfCommunityChestJailCard(player1);
            Assert.True(dealer.OwnsAGetOutOfJailCard(player1));
            dealer.UsesAGetOutOfJailCard(player1);
            Assert.False(dealer.OwnsAGetOutOfJailCard(player1));
        }
    }
}
