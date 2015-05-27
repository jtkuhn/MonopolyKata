using MonopolyKata;
using MonopolyKata.PropertySquares;
using MonopolyKata.PropertySquares.Rent;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestProject1
{

    [TestFixture]
    public class PlayerTest
    {
        private Player player1;
        private BoardFactory bd = new BoardFactory();
        private Board board;

        [SetUp]
        public void Init()
        {
            board = bd.Create();
            player1 = new Player("Bob", new Board());
        }

        [Test]
        public void WhenPlayerIsCreated_InitializedCorrectly()
        {
            Assert.AreEqual(0, player1.Position);
            Assert.AreEqual("Bob", player1.Name);
        }

        [Test]
        public void PlayerMove_IncrementsPositionCorrectly()
        {
            player1.Move(2);
            player1.Move(7);
            player1.Move(5);
            Assert.AreEqual(14, player1.Position);
        }

        [Test]
        public void PlayerMove_WrapsAroundAt40()
        {
            player1.Move(35);
            player1.Move(7);
            Assert.AreEqual(2, player1.Position);
        }

        [Test]
        public void WhenPlayerIsCreated_StartsWith1500Dollars()
        {
            Assert.AreEqual(1500, player1.Money);
        }


        [Test]
        public void WhenPlayerMovesPastGo_TheyGet200Dollars()
        {
            player1.Position = 30;
            player1.Move(20);
            Assert.AreEqual(10, player1.Position);
            Assert.AreEqual(1700, player1.Money);
        }

        [Test]
        public void WhenPlayerMortagesHisProperty_ItBecomesMortgaged()
        {
            Property prop = new Property(new RentStrategyMonopolizable(board), "testProperty");
            prop.IsLandedOn(player1);
            Assert.AreEqual(player1, prop.owner);
            Assert.IsFalse(prop.IsMortgaged);
            player1.Mortgage(prop);
            Assert.IsTrue(prop.IsMortgaged);
        }

        [Test]
        public void WhenPlayerUnmortgagesProperty_ItBecomesUnmortgaged()
        {
            Property prop = new Property(new RentStrategyMonopolizable(board), "testProperty");
            prop.IsLandedOn(player1);
            prop.IsMortgaged = true;
            player1.UnMortgage(prop);
            Assert.IsFalse(prop.IsMortgaged);
        }

        [Test]
        public void PlayerMortgage_WillNotChangeUnownedProperty()
        {
            Property prop = new Property(new RentStrategyMonopolizable(board), "testProperty");
            prop.IsLandedOn(new Player("hi", board));
            player1.Mortgage(prop);
            Assert.IsFalse(prop.IsMortgaged);
        }
    }
}
