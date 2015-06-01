using System;

namespace MonopolyKata.Cards
{
    public class PayPlayerMoneyCard : Card
    {
        private Banker banker;
        private int amount;

        public PayPlayerMoneyCard(String name, Banker banker, int amount) : base(name)
        {
            this.banker = banker;
            this.amount = amount;
        }

        public override void IsDrawn(Player player)
        {
            banker.GiveMoneyToPlayer(player, amount);
        }
    }
}
