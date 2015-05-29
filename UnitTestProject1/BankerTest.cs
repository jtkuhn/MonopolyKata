using MonopolyKata;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class BankerTest
    {
        private Player player1;
        private Banker banker;

        [SetUp]
        public void Setup()
        {
            banker = new Banker();
            player1 = new Player("Bob");
        }

        [Test]
        public void WhenBankerTakesMoneyFromPlayer_HisMoneyDecrementsAccordingly()
        {
            Assert.AreEqual(1500, player1.Money);
            banker.TakeMoneyFromPlayer(player1, 150);
            Assert.AreEqual(1350, player1.Money);
        }

        [Test]
        public void WhenBankerGivesMoneyToPlayer_HisMoneyIncrementsAccordingly()
        {
            Assert.AreEqual(1500, player1.Money);
            banker.GiveMoneyToPlayer(player1, 150);
            Assert.AreEqual(1650, player1.Money);
        }

        [Test]
        public void WhenBankerTransfersMoneyBetweenTwoPlayers_ItWorksAsItShould()
        {
            Player player2 = new Player("Bill");
            Assert.AreEqual(1500, player1.Money);
            Assert.AreEqual(1500, player2.Money);

            banker.TransferMoney(player1, player2, 100);
            Assert.AreEqual(1600, player1.Money);
            Assert.AreEqual(1400, player2.Money);
        }
    }
}
