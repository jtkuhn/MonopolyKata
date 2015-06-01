using System;

namespace MonopolyKata.Cards
{
    public class MovePlayerNumberOfSpacesCard : Card
    {
        private Board board;
        private int amount;

        public MovePlayerNumberOfSpacesCard(String name, Board board, int amount) : base(name)
        {
            this.board = board;
            this.amount = amount;
        }

        public override void IsDrawn(Player player)
        {
            board.MovePlayer(player, amount);
        }
    }
}
