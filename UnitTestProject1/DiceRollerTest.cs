using MonopolyKata.PropertySquares.Rent;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    class DiceRollerTest
    {
        private DiceRoller diceRoller;

        [SetUp]
        public void Setup()
        {
            diceRoller = new DiceRoller();
        }

        [Test]
        public void GetLastRoll_ReturnsTheLastRoll()
        {
            int lastRoll = diceRoller.GetNextRoll();
            Assert.AreEqual(lastRoll, diceRoller.GetLastRoll());
        }
    }
}
