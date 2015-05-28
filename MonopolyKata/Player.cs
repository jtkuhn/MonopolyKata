using System;
using MonopolyKata.PropertySquares;

namespace MonopolyKata
{
    public class Player
    {
        public String Name { get; set; }
        public int Money { get; set; }
        public int Position { get; set; }

        public Player(string name)
        {
            Name = name;
            Position = 0;
            Money = 1500;
        }
    }
}
