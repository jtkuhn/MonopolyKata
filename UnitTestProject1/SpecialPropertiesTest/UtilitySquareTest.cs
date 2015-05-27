using MonopolyKata;
using NUnit.Framework;

namespace UnitTestProject1.SpecialPropertiesTest
{
    [TestFixture]
    public class UtilitySquareTest
    {
        private Player player;
        private Board board;

        [SetUp]
        public void Setup()
        {
            board = new Board();
            player = new Player("Tester", board);
        }

        [Test]
        public void WhenOneUtilityIsOwned_GetNumberOfUtilities_ReturnsOne()
        {
            Player player1 = new Player("Hi", board);
            player1.Move(12);
            Assert.AreEqual(1, board.GetNumberOfOwnedUtilities());
        }

        [Test]
        public void WhenTwoUtilitiesAreOwned_GetNumber_ReturnsTwo()
        {
            Player player1 = new Player("peekaboo", board);
            player1.Move(12);
            player1.Move(16);
            Assert.AreEqual(2, board.GetNumberOfOwnedUtilities());
        }
    }
}
