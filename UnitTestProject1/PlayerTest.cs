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
        private Realtor realtor;

        [SetUp]
        public void Init()
        {
            realtor = new Realtor();
            board = bd.Create(realtor);
            player1 = new Player("Bob", new Board(realtor));
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
    }
}
