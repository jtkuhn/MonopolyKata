using System;

namespace MonopolyKata.PropertySquares.Rent
{
    public class RentStrategyRailroad : IRentStrategy
    {
        private Board board;
        private bool _isMortgaged;

        public RentStrategyRailroad(Board board)
        {
            this.board = board;
            _isMortgaged = false;
        }

        public void GetRent(Player owner, Player player)
        {
            if (!_isMortgaged)
            {
                int rentToBePaid = 25*(int) Math.Pow(2, board.GetNumberOfRailroads(owner) - 1);
                player.Money -= rentToBePaid;
                owner.Money += rentToBePaid;
            }
        }

        public void GetMortgageStatus(bool isMortgaged)
        {
            _isMortgaged = isMortgaged;
        }
    }
}
