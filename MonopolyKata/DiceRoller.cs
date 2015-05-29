using System;

namespace MonopolyKata.PropertySquares.Rent
{
    public class DiceRoller
    {
        private Random rand;
        private int die1;
        private int die2;

        public DiceRoller()
        {
            rand = new Random();
        }

        public virtual int GetNextRoll()
        {
            RollTwoDice();
            return die1 + die2;
        }

        public virtual int GetLastRoll()
        {
            return die1 + die2;
        }

        public virtual bool WasDoubles()
        {
            return (die1 == die2);
        }

        private void RollTwoDice()
        {
            die1 = rand.Next(1, 7);
            die2 = rand.Next(1, 7);
        }
    }
}