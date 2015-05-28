namespace MonopolyKata
{
    public class BoardFactory
    {
        public Board Create(Realtor realtor)
        {
            return new Board(realtor);
        }
    }
}
