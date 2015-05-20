using MonopolyKata;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class RealtorTest
    {
        private Realtor realtor;
        private Board board;
        private Property prop;
        private Player player;


        [SetUp]
        public void Setup()
        {
            board = new Board();
            realtor = new Realtor(board);
            prop = board.GetPropertyAt(5);
            player = new Player("Bob");
        }

        [Test]
        public void WhenRealtorIsInitialized_AllPropertyOwnersAreNull()
        {
            for (int i = 0; i < board.Size; i++)
            Assert.Null(realtor.GetOwner(board.GetPropertyAt(i)));
        }

        [Test]
        public void SetOwner_GivesThePropertyAnOwner()
        {
            realtor.SetOwner(prop, player);
            Assert.AreEqual(player, realtor.GetOwner(prop));
        }

        [Test]
        public void GetOwner_GetsThePropertyOwner()
        {
            player = realtor.GetOwner(prop);
            Assert.Null(player);
            Player player2 = new Player("Joe");
            realtor.SetOwner(prop, player2);
            Assert.AreEqual(player2, realtor.GetOwner(prop));
        }
    }
}
