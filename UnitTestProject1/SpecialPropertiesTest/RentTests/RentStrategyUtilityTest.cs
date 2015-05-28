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
        private Mock<Realtor> mockRealtor;
        private Mock<DiceRoller> mockDiceRoller;
        private Board board;

        [SetUp]
        public void Setup()
        {
            mockDiceRoller = new Mock<DiceRoller>();
            mockRealtor = new Mock<Realtor>();
            board = new Board(mockRealtor.Object, new JailWarden());
            rentStrategy = new RentStrategyUtility(mockDiceRoller.Object, mockRealtor.Object);
        }

        [Test]
        public void WhenOneUtilityIsOwned_RentIs4TimesDiceRoll()
        {
            mockRealtor.Setup(x => x.GetNumberOfOwnedUtilities()).Returns(1);
            mockDiceRoller.Setup(x => x.GetLastRoll()).Returns(5);
            Player player1 = new Player("testPlayer1");
            rentStrategy.GetRent(new Player("bob"), player1);
            Assert.AreEqual(1480, player1.Money);
        }

        [Test]
        public void WhenTwoUtilitiesAreOwned_RentIs10TimesDiceRoll()
        {
            mockRealtor.Setup(x => x.GetNumberOfOwnedUtilities()).Returns(2);
            mockDiceRoller.Setup(x => x.GetLastRoll()).Returns(6);
            Player player1 = new Player("playerWhoLosesMoney");
            Player player2 = new Player("ownerWhoGetsMoney");
            rentStrategy.GetRent(player1, player2);
            Assert.AreEqual(1560, player1.Money);
            Assert.AreEqual(1440, player2.Money);

        }
    }
}
