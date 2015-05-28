using MonopolyKata;
using MonopolyKata.PropertySquares;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class LuxurySquareTest
    {
        private Player player1 = new Player("Jill", new Board(new Realtor()));
        private Square prop1 = new LuxuryTaxSquare();

        [Test]
        public void WhenLuxuryTaxIsLandedOn_PlayerLoses75Dollars()
        {
            Assert.AreEqual(1500, player1.Money);
            prop1.IsLandedOn(player1);
            Assert.AreEqual(1425, player1.Money);
        }
    }
}
