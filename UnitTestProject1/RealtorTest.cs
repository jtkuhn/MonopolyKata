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
            player = new Player("Bob", new Board());
        }

        [Test]
        public void WhenRealtorIsInitialized_AllPropertyOwnersAreNull()
        {
            for (int i = 0; i < board.Size; i++)
            Assert.Null(realtor.GetOwnerOf(board.GetPropertyAt(i)));
        }

        [Test]
        public void SetOwner_GivesThePropertyAnOwner()
        {
            realtor.SetOwnerOf(prop, player);
            Assert.AreEqual(player, realtor.GetOwnerOf(prop));
        }

        [Test]
        public void GetOwner_GetsThePropertyOwner()
        {
            player = realtor.GetOwnerOf(prop);
            Assert.Null(player);
            Player player2 = new Player("Joe", new Board());
            realtor.SetOwnerOf(prop, player2);
            Assert.AreEqual(player2, realtor.GetOwnerOf(prop));
        }
    }
}
