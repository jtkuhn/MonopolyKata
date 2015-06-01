using System;

namespace MonopolyKata.Cards
{
    public class SendPlayerToJailCard : Card
    {
        private JailWarden jailWarden;

        public SendPlayerToJailCard(String name, JailWarden jailWarden) : base(name)
        {
            this.jailWarden = jailWarden;
        }

        public override void IsDrawn(Player player)
        {
            jailWarden.MovePlayerToJail(player);
        }
    }
}
