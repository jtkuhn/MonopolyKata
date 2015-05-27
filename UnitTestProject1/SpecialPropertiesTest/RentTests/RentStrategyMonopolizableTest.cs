using MonopolyKata;
using MonopolyKata.PropertySquares.Properties;
using MonopolyKata.PropertySquares.Rent;
using Moq;
using NUnit.Framework;

namespace UnitTestProject1.SpecialPropertiesTest.RentTests
{
    [TestFixture]
    public class RentStrategyMonopolizableTest
    {
        private IRentStrategy rentStrategy;
        private MonopolizableProperty property;
        private Mock<Board> mockBoard;

        [SetUp]
        public void Setup()
        {
            mockBoard = new Mock<Board>();
            rentStrategy = new RentStrategyMonopolizable(mockBoard.Object);
            property = new MonopolizableProperty(rentStrategy, "testProp");
        }

        [Test]
        public void WhenPropertyIsOwned_RentIsCharged()
        {
            property.rent = 18;
            Player player1 = new Player("Fred", mockBoard.Object);
            ((RentStrategyMonopolizable) rentStrategy).SetRent(property);
            rentStrategy.GetRent(new Player("Kendra", mockBoard.Object), player1);
            Assert.AreEqual(1482, player1.Money);
        }
    }
}
