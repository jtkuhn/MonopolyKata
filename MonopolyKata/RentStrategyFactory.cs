using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata
{
    public class RentStrategyFactory
    {
        public IRentStrategy CreateRailroadStrategy(Realtor realtor)
        {
            return new RentStrategyRailroad(realtor);
        }

        public IRentStrategy CreateUtilityStrategy(DiceRoller diceRoller, Realtor realtor)
        {
            return new RentStrategyUtility(diceRoller, realtor);
        }

        public IRentStrategy CreateMonopolizableStrategy(Board board)
        {
            return new RentStrategyMonopolizable(board);
        }
    }
}
