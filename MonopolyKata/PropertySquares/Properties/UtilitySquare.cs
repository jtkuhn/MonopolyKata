using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata.PropertySquares
{
    public class UtilitySquare : Property
    {
        public UtilitySquare(IRentStrategy rentStrategy, string nm) : base(rentStrategy, nm, cost: 150, rent: 0)
        {
        }
    }
}
