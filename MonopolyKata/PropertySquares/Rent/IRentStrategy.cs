namespace MonopolyKata.PropertySquares.Rent
{
    public interface IRentStrategy
    {
        void GetRent(Player owner, Player player);
        void GetMortgageStatus(bool isMortgaged);
    }
}
