using System;

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
            int size = board.Size;
            for (int i = 1; i < distance; i++)
            {
                board.GetPropertyAt((Position + i)%size).IsPassedBy(this);
            }
            Position += distance;
            Position %= size;
            board.GetPropertyAt(Position).IsLandedOn(this);
        }
    }
}
