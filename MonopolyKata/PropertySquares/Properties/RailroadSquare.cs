using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata.PropertySquares
{
    public class RailroadSquare : Property
    {
        public RailroadSquare(IRentStrategy rs, Banker banker, string propertyName, Realtor realtor) : base(rs, banker, propertyName, realtor, cost: 200, rent: 25)
        {
        }
    }
}
