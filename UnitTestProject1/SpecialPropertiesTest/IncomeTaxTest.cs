using MonopolyKata;
using MonopolyKata.PropertySquares;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class IncomeTaxTest
    {
        private Player player1;
        private Square prop = new IncomeTaxSquare();

        [SetUp]
        public void Init()
        {
            player1 = new Player("Joe", new Board());
        }
        [Test]
        public void WhenPlayerWith1500LandsOnIncomeTax_MoneyDecreasesBy10Percent()
        {
            Assert.AreEqual(1500, player1.Money);
            prop.IsLandedOn(player1);
            Assert.AreEqual(1350, player1.Money);
            prop.IsLandedOn(player1);
            Assert.AreEqual(1215, player1.Money);
        }

        [Test]
        public void WhenPlayerWith2000LandsOnIncomeTax_MoneyDecreasesBy200Dollars()
        {
            player1.Money = 2000;
            prop.IsLandedOn(player1);
            Assert.AreEqual(1800, player1.Money);
        }

        [Test]
        public void WhenPlayerWith2100LandsOnIncomeTax_MoneyDecreasedBy200Dollars()
        {
            player1.Money = 2100;
            prop.IsLandedOn(player1);
            Assert.AreEqual(1900, player1.Money);
        }

    }
}
