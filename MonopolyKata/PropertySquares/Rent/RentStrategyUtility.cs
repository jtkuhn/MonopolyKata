namespace MonopolyKata.PropertySquares.Rent
{
    public class RentStrategyUtility : IRentStrategy
    {
        private Realtor realtor;
        private DiceRoller diceRoller;
        private bool _isMortgaged;

        public RentStrategyUtility(DiceRoller diceRoller, Realtor realtor)
        {
            this.realtor = realtor;
            this.diceRoller = diceRoller;
            _isMortgaged = false;
        }

        public void GetRent(Player landlord, Player tenant)
        {
            if (!_isMortgaged)
            {
                int lastRoll = diceRoller.GetLastRoll();
                int price;
                if (realtor.GetNumberOfOwnedUtilities() == 1) price = lastRoll*4;
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