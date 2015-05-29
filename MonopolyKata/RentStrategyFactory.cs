using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata
{
    public class RentStrategyFactory
    {
        private Realtor realtor;

        public RentStrategyFactory(Realtor realtor)
        {
            this.realtor = realtor;
        }

        public IRentStrategy CreateRailroadStrategy()
        {
            return new RentStrategyRailroad(realtor);
        }

        public IRentStrategy CreateUtilityStrategy(DiceRoller diceRoller)
        {
            return new RentStrategyUtility(diceRoller, realtor);
        }

        public IRentStrategy CreateMonopolizableStrategy(Board board)
        {
            return new RentStrategyMonopolizable(board);
        }
    }
}
