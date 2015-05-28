using MonopolyKata.PropertySquares.Rent;
using Moq;
using NUnit.Framework;

namespace MonopolyKata
{
    public class RentStrategyRailroadTest
    {
        private IRentStrategy rentStrategy;
        private Mock<Realtor> mockRealtor;
        private Board board;

        [SetUp]
        public void Setup()
        {
            mockRealtor = new Mock<Realtor>();
            board = new Board(mockRealtor.Object);
            rentStrategy = new RentStrategyRailroad(mockRealtor.Object);
        }

        [Test]
        public void WhenOwnerHasOneRailroad_RentIs25Dollars()
        {
            mockRealtor.Setup(x => x.GetNumberOfOwnedRailroads(It.IsAny<Player>())).Returns(1);
            Player player1 = new Player("hi", board);
            rentStrategy.GetRent(new Player("bob", board), player1);
            Assert.AreEqual(1475, player1.Money);
        }

        [Test]
        public void WhenOwnerHasThreeRailroads_RentIs100Dollars()
        {
            mockRealtor.Setup(x => x.GetNumberOfOwnedRailroads(It.IsAny<Player>())).Returns(3);
            Player player1 = new Player("whatever", board);
            rentStrategy.GetRent(new Player("bob", board), player1);
            Assert.AreEqual(1400, player1.Money);
        }
    }
}
