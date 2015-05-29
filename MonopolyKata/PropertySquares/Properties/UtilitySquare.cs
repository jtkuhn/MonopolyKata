using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata.PropertySquares
{
    public class UtilitySquare : Property
    {
        public UtilitySquare(IRentStrategy rentStrategy, Banker banker, string nm, Realtor realtor) : base(rentStrategy, banker, nm, realtor, cost: 150, rent: 0)
        {
        }
    }
}
