using MonopolyKata;
using MonopolyKata.PropertySquares.Rent;
using Moq;
using NUnit.Framework;

namespace UnitTestProject1.SpecialPropertiesTest.RentTests
{
    [TestFixture]
    class RentStrategyUtilityTest
    {
        private IRentStrategy rentStrategy;
        private Mock<Board> mockBoard;
        private Mock<DiceRoller> mockDiceRoller;

        [SetUp]
        public void Setup()
        {
            mockDiceRoller = new Mock<DiceRoller>();
            mockBoard = new Mock<Board>();
            rentStrategy = new RentStrategyUtility(mockDiceRoller.Object, mockBoard.Object);
        }

        [Test]
        public void WhenOneUtilityIsOwned_RentIs4TimesDiceRoll()
        {
            mockBoard.Setup(x => x.GetNumberOfOwnedUtilities()).Returns(1);
            mockDiceRoller.Setup(x => x.GetLastRoll()).Returns(5);
            Player player1 = new Player("testPlayer1", mockBoard.Object);
            rentStrategy.GetRent(new Player("bob", mockBoard.Object), player1);
            Assert.AreEqual(1480, player1.Money);
        }

        [Test]
        public void WhenTwoUtilitiesAreOwned_RentIs10TimesDiceRoll()
        {
            mockBoard.Setup(x => x.GetNumberOfOwnedUtilities()).Returns(2);
            mockDiceRoller.Setup(x => x.GetLastRoll()).Returns(6);
            Player player1 = new Player("playerWhoLosesMoney", mockBoard.Object);
            Player player2 = new Player("ownerWhoGetsMoney", mockBoard.Object);
            rentStrategy.GetRent(player1, player2);
            Assert.AreEqual(1560, player1.Money);
            Assert.AreEqual(1440, player2.Money);

        }
    }
}
