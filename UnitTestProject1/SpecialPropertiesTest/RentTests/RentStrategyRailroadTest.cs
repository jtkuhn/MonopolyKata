using MonopolyKata.PropertySquares.Rent;
using Moq;
using NUnit.Framework;

namespace MonopolyKata
{
    public class RentStrategyRailroadTest
    {
        private IRentStrategy rentStrategy;
        private Mock<Board> mockBoard;

        [SetUp]
        public void Setup()
        {
            mockBoard = new Mock<Board>();
            rentStrategy = new RentStrategyRailroad(mockBoard.Object);
        }

        [Test]
        public void WhenOwnerHasOneRailroad_RentIs25Dollars()
        {
            mockBoard.Setup(x => x.GetNumberOfRailroads(It.IsAny<Player>())).Returns(1);
            Player player1 = new Player("hi", mockBoard.Object);
            rentStrategy.GetRent(new Player("bob", mockBoard.Object), player1);
            Assert.AreEqual(1475, player1.Money);
        }

        [Test]
        public void WhenOwnerHasThreeRailroads_RentIs100Dollars()
        {
            mockBoard.Setup(x => x.GetNumberOfRailroads(It.IsAny<Player>())).Returns(3);
            Player player1 = new Player("whatever", mockBoard.Object);
            rentStrategy.GetRent(new Player("bob", mockBoard.Object), player1);
            Assert.AreEqual(1400, player1.Money);
        }
    }
}
