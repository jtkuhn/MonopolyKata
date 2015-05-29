namespace MonopolyKata.PropertySquares.Rent
{
    public interface IRentStrategy
    {
        int GetRent(Player owner, Player player);
        void GetMortgageStatus(bool isMortgaged);
    }
}
