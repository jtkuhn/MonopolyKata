using MonopolyKata;
using MonopolyKata.Cards;
using Moq;
using NUnit.Framework;

namespace UnitTestProject1.CardsTests
{
    [TestFixture]
    public class TakeMoneyFromPlayerCardTests
    {
        private Mock<Banker> mockBanker;
        private Mock<Player> mockPlayer;
        private Card testCard;

        [SetUp]
        public void Setup()
        {
            mockBanker = new Mock<Banker>();
            mockPlayer = new Mock<Player>("Jim");

            testCard = new TakeMoneyFromPlayerCard("Test", mockBanker.Object, 5);
        }

        [Test]
        public void WhenTakeMoneyFromPlayerCardIsDrawn_BankerTakesMoneyFromPlayer()
        {
            mockBanker.Setup(x => x.TakeMoneyFromPlayer(mockPlayer.Object, It.IsAny<int>())).Verifiable();
            testCard.IsDrawn(mockPlayer.Object);
            mockBanker.Verify();
        }
    }
}
