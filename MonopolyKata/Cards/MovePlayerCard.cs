using System;

namespace MonopolyKata.Cards
{
    public class MovePlayerCard : Card
    {
        private Board board;
        private int index;

        public MovePlayerCard(String name, Board board, int index) : base(name)
        {
            this.board = board;
            this.index = index;
        }

        public override void IsDrawn(Player player)
        {
            int distance = CalculateDistance(player);
            board.MovePlayer(player, distance);
        }

        private int CalculateDistance(Player player)
        {
            int amountToMove = index - player.Position;
            amountToMove += board.Size;
            amountToMove %= board.Size;
            return amountToMove;
        }
    }
}
