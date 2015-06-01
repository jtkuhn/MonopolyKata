using MonopolyKata;
using MonopolyKata.Cards;
using MonopolyKata.PropertySquares;
using MonopolyKata.PropertySquares.Properties;
using MonopolyKata.PropertySquares.Rent;
using Moq;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class PropertyTest
    {
        private Player player1;
        private Player player2;
        private Property prop;
        private Mock<Board> board;
        private IRentStrategy rentStrategy;
        private Realtor realtor;
        private CardDealer dealer;

        [SetUp]
        public void Init()
        {
            realtor = new Realtor();
            board = new Mock<Board>(realtor, new JailWarden(), new Banker(), dealer, new DiceRoller());
            player1 = new Player("One");
            player2 = new Player("Two");
            rentStrategy = new RentStrategyMonopolizable(board.Object);
            prop = new MonopolizableProperty(rentStrategy, new Banker(), "TestProperty", realtor, Color.Brown, 100, 20);
        }

        [Test]
        public void WhenConstructorFires_PropertiesAreCorrectlyInitialized()
        {
            Property BoardWalk = new Property(rentStrategy, new Banker(), "BoardWalk", realtor, cost: 10000000, rent: 2);
            Assert.AreEqual("BoardWalk", BoardWalk.Name);
            Assert.Null(realtor.GetOwnerOf(prop));
        }

       [Test]
        public void WhenUnownedPropertyIsLandedOn_PlayerLosesCost()
        {
            Assert.AreEqual(1500, player1.Money);
            prop.IsLandedOn(player1);
            Assert.AreEqual(1400, player1.Money);
        }

        [Test]
        public void WhenUnownedPropertyIsLandedOn_OwnerChangesToPlayer()
        {
            Assert.Null(realtor.GetOwnerOf(prop));
            prop.IsLandedOn(player1);
            Assert.AreEqual(player1, realtor.GetOwnerOf(prop));
        }

        [Test]
        public void WhenPropertyIsLandedOn_PlayerMoneyIsReducedByRent()
        {
            board.Setup(x => x.IsPartOfMonopoly(It.IsAny<MonopolizableProperty>())).Returns(false);
            Assert.AreEqual(1500, player1.Money);
            realtor.SetOwnerOf(prop, player2);
            Assert.AreEqual(player2, realtor.GetOwnerOf(prop));
            prop.IsLandedOn(player1);
            Assert.AreEqual(1480, player1.Money);
        }

        [Test]
        public void WhenPropertyIsLandedOn_OwnersMoneyIsIncreasedByRent()
        {
            Assert.AreEqual(1500, player1.Money);
            realtor.SetOwnerOf(prop, player1);
            prop.IsLandedOn(player2);
            Assert.AreEqual(1520, player1.Money);
        }

        [Test]
        public void MortgagedProperty_ChargesNoRent()
        {
            Assert.AreEqual(1500, player1.Money);
            prop.IsLandedOn(new Player("bob"));
            prop.IsMortgaged = true;
            prop.IsLandedOn(player1);
            Assert.AreEqual(1500, player1.Money);
            prop.IsMortgaged = false;
            prop.IsLandedOn(player1);
            Assert.AreNotEqual(1500, player1.Money);
        }
    }
}
