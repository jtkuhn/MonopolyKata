using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata.PropertySquares
{
    public class UtilitySquare : Property
    {
        public UtilitySquare(IRentStrategy rentStrategy, string nm, Realtor realtor) : base(rentStrategy, nm, realtor, cost: 150, rent: 0)
        {
        }
    }
}
