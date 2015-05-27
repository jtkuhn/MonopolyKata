using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata.PropertySquares
{
    public class RailroadSquare : Property
    {
        public RailroadSquare(IRentStrategy rs, string propertyName) : base(rs, propertyName, 200, 25)
        {
        }
    }
}
