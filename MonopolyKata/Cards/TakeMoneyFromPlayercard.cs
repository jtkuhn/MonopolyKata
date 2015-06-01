using System;

namespace MonopolyKata.Cards
{
    public class TakeMoneyFromPlayerCard : Card
    {
        private Banker banker;
        private int amount;

        public TakeMoneyFromPlayerCard(String name, Banker banker, int amount) : base(name)
        {
            this.banker = banker;
            this.amount = amount;
        }

        public override void IsDrawn(Player player)
        {
            banker.TakeMoneyFromPlayer(player, amount);
        }
    }
}
