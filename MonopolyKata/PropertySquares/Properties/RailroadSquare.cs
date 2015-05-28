using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata.PropertySquares
{
    public class RailroadSquare : Property
    {
        public RailroadSquare(IRentStrategy rs, string propertyName, Realtor realtor) : base(rs, propertyName, realtor, cost: 200, rent: 25)
        {
        }
    }
}
