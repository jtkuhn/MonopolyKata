namespace MonopolyKata.PropertySquares.Rent
{
    public class RentStrategyUtility : IRentStrategy
    {
        private Board board;
        private DiceRoller diceRoller;
        private bool _isMortgaged;

        public RentStrategyUtility(DiceRoller diceRoller, Board board)
        {
            this.board = board;
            this.diceRoller = diceRoller;
            _isMortgaged = false;
        }

        public void GetRent(Player landlord, Player tenant)
        {
            if (!_isMortgaged)
            {
                int lastRoll = diceRoller.GetLastRoll();
                int price;
                if (board.GetNumberOfOwnedUtilities() == 1) price = lastRoll*4;
                else price = lastRoll*10;
                landlord.Money += price;
                tenant.Money -= price;
            }
        }

        public void GetMortgageStatus(bool isMortgaged)
        {
            _isMortgaged = isMortgaged;
        }
    }
}