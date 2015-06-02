using MonopolyKata.Cards;
using MonopolyKata.PropertySquares.Rent;
using Moq;
using NUnit.Framework;

namespace MonopolyKata
{
    public class RentStrategyRailroadTest
    {
        private IRentStrategy rentStrategy;
        private Mock<Realtor> mockRealtor;

        [SetUp]
        public void Setup()
        {
            mockRealtor = new Mock<Realtor>();
            rentStrategy = new RentStrategyRailroad(mockRealtor.Object);
        }

        [Test]
        public void WhenOwnerHasOneRailroad_RentIs25Dollars()
        {
            mockRealtor.Setup(x => x.GetNumberOfOwnedRailroads(It.IsAny<Player>())).Returns(1);
            Player player1 = new Player("hi");
            Assert.AreEqual(25, rentStrategy.GetRent(new Player("bob"), player1));
        }

        [Test]
        public void WhenOwnerHasThreeRailroads_RentIs100Dollars()
        {
            mockRealtor.Setup(x => x.GetNumberOfOwnedRailroads(It.IsAny<Player>())).Returns(3);
            Player player1 = new Player("whatever");
            Assert.AreEqual(100, rentStrategy.GetRent(new Player("bob"), player1));
        }
    }
}
