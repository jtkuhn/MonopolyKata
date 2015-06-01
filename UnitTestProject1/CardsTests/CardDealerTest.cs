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
            realtor = new Realtor();
            jailWarden = new JailWarden();
            board = new Board(realtor, jailWarden, banker, new DiceRoller());
            dealer = new CardDealer(banker, jailWarden, realtor, board);
            
        }

        [Test]
        public void InitializeCards_CreatesAllTheCardsToUse()
        {
            dealer.InitializeCards();
            Assert.NotNull(dealer.DrawNextChanceCard(new Player("Bob"))); 
            Assert.NotNull(dealer.DrawNextCommunityChestCard(new Player("Bob")));
        }
    }
}
