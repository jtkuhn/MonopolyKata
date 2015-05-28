using System;
using MonopolyKata.PropertySquares;

namespace MonopolyKata
{
    public class Player
    {
        public String Name { get; set; }
        public int Money { get; set; }
        public int Position { get; set; }
        private Board board;

        public Player(String name, Board board)
        {
            Name = name;
            this.board = board;
            Position = 0;
            Money = 1500;
        }

        public void Move(int distance)
        {
            for (int i = 1; i < distance; i++)
            {
                board.PlayerPassesBy(this, Position + i);
            }
            Position = board.PlayerLandsOn(this, Position + distance);
        }
    }
}
