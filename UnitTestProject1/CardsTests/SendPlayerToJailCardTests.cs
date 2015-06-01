using MonopolyKata;
using MonopolyKata.Cards;
using Moq;
using NUnit.Framework;

namespace UnitTestProject1.CardsTests
{
    [TestFixture]
    public class SendPlayerToJailCardTests
    {
        private Mock<JailWarden> mockJailWarden;
        private Mock<Player> mockPlayer;
        private Card testCard;

        [SetUp]
        public void Setup()
        {
            mockJailWarden = new Mock<JailWarden>();
            mockPlayer = new Mock<Player>("Jim");

            testCard = new SendPlayerToJailCard("Test", mockJailWarden.Object);
        }

        [Test]
        public void WhenTakeMoneyFromPlayerCardIsDrawn_BankerTakesMoneyFromPlayer()
        {
            mockJailWarden.Setup(x => x.MovePlayerToJail(mockPlayer.Object)).Verifiable();
            testCard.IsDrawn(mockPlayer.Object);
            mockJailWarden.Verify();
        }
    }
}
