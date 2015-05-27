namespace MonopolyKata.PropertySquares.Rent
{
    public class RentStrategyMonopolizable : IRentStrategy
    {
        private Board board;
        private int rent;
        private bool _isMortgaged;

        public RentStrategyMonopolizable(Board board)
        {
            this.board = board;
            _isMortgaged = false;
        }

        public void GetRent(Player owner, Player player)
        {
            if (!_isMortgaged)
            {
                player.Money -= rent;
                owner.Money += rent;
            }
        }

    public void GetMortgageStatus(bool isMortgaged)
        {
            _isMortgaged = isMortgaged;
        }

        public void SetRent(Property prop)
        {
            rent = prop.rent;
        }
    }
}
