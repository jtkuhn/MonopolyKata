using System;

namespace MonopolyKata
{
    public class Player
    {
        public String Name { get; set; }
        public int Money { get; set; }
        public int Position { get; set; }


        public Player(String name)
        {
            Name = name;
            Position = 0;
            Money = 1500;
        }
        public void Move(Board board, int distance)
        {
            for (int i = 1; i < distance; i++)
            {
                board.GetPropertyAt((Position + i)%40).IsPassedBy(this);
            }
            Position += distance;
            Position %= 40;
            board.GetPropertyAt(Position).IsLandedOn(this);
        }
    }
}
