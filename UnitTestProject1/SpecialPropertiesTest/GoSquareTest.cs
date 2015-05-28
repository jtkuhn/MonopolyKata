using MonopolyKata;
using MonopolyKata.PropertySquares;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class GoSquareTest
    {
        private Square gs = new GoSquare();
        private Player player1;

        [SetUp]
        public void Init()
        {
            player1 = new Player("t");
        }

        [Test]
        public void WhenConstructorFires_GoSquareIsInitialized()
        {
            Assert.AreEqual("Go", gs.Name);
        }

        [Test]
        public void WhenLandsOnIsCalled_PlayerGets200Dollars()
        {
            gs.IsLandedOn(player1);
            Assert.AreEqual(1700, player1.Money);
        }

        [Test]
        public void WhenPassByIsCalled_PlayerCollects200Dollars()
        {
            gs.IsPassedBy(player1);
            Assert.AreEqual(1700, player1.Money);
        }

    }
}
