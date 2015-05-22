using MonopolyKata;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class PropertyTest
    {
        private Player player1;
        private Player player2;
        private Property prop;
        private Board board;
        private Realtor realtor;

        [SetUp]
        public void Init()
        {
            board = new Board();
            player1 = new Player("One", board);
            player2 = new Player("Two", board);
            prop = new Property("TestProperty", 100, 20);
            board.SetPropertyAt(5, prop);
            realtor = new Realtor(board);
        }

        [Test]
        public void WhenConstructorFires_PropertiesAreCorrectlyInitialized()
        {
            Property BoardWalk = new Property("BoardWalk");
            Assert.AreEqual("BoardWalk", BoardWalk.Name);
            Assert.Null(prop.owner);
        }

        [Test]
        public void SetOwner_ChangesTheOwner()
        {
            prop.SetOwner(player1);
            Assert.AreEqual(player1, prop.owner);
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
            Assert.Null(prop.owner);
            prop.IsLandedOn(player1);
            Assert.AreEqual(player1, prop.owner);
        }

        [Test]
        public void WhenPropertyIsLandedOn_PlayerMoneyIsReducedByRent()
        {
            Assert.AreEqual(1500, player1.Money);
            prop.SetOwner(player2);
            prop.IsLandedOn(player1);
            Assert.AreEqual(1480, player1.Money);
        }

        [Test]
        public void WhenPropertyIsLandedOn_OwnersMoneyIsIncreasedByRent()
        {
            Assert.AreEqual(1500, player1.Money);
            prop.SetOwner(player1);
            prop.IsLandedOn(player2);
            Assert.AreEqual(1520, player1.Money);
        }

    }
}
