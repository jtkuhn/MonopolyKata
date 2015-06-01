using System;

namespace MonopolyKata
{
    public class Player
    {
        public String Name { get; set; }
        public int Money { get; set; }
        public virtual int Position { get; set; }

        public Player(string name)
        {
            Name = name;
            Position = 0;
            Money = 1500;
        }
    }
}
