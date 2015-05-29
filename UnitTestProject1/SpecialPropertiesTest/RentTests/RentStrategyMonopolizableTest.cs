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
        private Banker banker;

        [SetUp]
        public void Setup()
        {
            banker = new Banker();
            realtor = new Realtor();
            mockBoard = new Mock<Board>(realtor, new JailWarden(), banker, new DiceRoller());
            rentStrategy = new RentStrategyMonopolizable(mockBoard.Object);
            property = new MonopolizableProperty(rentStrategy, banker, "testProp", realtor, Color.Brown);
        }

        [Test]
        public void WhenPropertyIsOwned_RentIsCharged()
        {
            property.rent = 18;
            mockBoard.Setup(x => x.IsPartOfMonopoly(property)).Returns(false);
            Player player1 = new Player("Fred");
            ((RentStrategyMonopolizable) rentStrategy).SetRent(property);
            Assert.AreEqual(18, rentStrategy.GetRent(new Player("Freddie"), player1));
        }

        [Test]
        public void WhenPropertyIsOwnedInMonopoly_RentIsChargedDouble()
        {
            property.rent = 18;
            mockBoard.Setup(x => x.IsPartOfMonopoly(property)).Returns(true);
            Player player1 = new Player("Bob");
            ((RentStrategyMonopolizable) rentStrategy).SetRent(property);
            Assert.AreEqual(36, rentStrategy.GetRent(new Player("hi"), player1));
        }
    }
}
