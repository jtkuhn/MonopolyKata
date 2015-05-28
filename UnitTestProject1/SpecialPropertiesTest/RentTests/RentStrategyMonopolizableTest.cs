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
        private Realtor realtor;

        [SetUp]
        public void Setup()
        {
            realtor = new Realtor();
            mockBoard = new Mock<Board>();
            rentStrategy = new RentStrategyMonopolizable(mockBoard.Object);
            property = new MonopolizableProperty(rentStrategy, "testProp", realtor, Color.Brown);
        }

        [Test]
        public void WhenPropertyIsOwned_RentIsCharged()
        {
            property.rent = 18;
            mockBoard.Setup(x => x.IsPartOfMonopoly(property)).Returns(false);
            Player player1 = new Player("Fred", mockBoard.Object);
            ((RentStrategyMonopolizable) rentStrategy).SetRent(property);
            rentStrategy.GetRent(new Player("Freddie", mockBoard.Object), player1);
            Assert.AreEqual(1482, player1.Money);
        }

        [Test]
        public void WhenPropertyIsOwnedInMonopoly_RentIsChargedDouble()
        {
            property.rent = 18;
            mockBoard.Setup(x => x.IsPartOfMonopoly(property)).Returns(true);
            Player player1 = new Player("Bob", mockBoard.Object);
            ((RentStrategyMonopolizable) rentStrategy).SetRent(property);
            rentStrategy.GetRent(new Player("hi", mockBoard.Object), player1);
            Assert.AreEqual(1464, player1.Money);
        }
    }
}
