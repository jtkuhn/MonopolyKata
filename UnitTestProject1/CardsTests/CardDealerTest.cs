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


    }
}
