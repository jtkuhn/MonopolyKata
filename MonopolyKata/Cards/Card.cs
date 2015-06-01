using System;

namespace MonopolyKata
{
    public class Card
    {
        public String Name;

        public Card(String name)
        {
            Name = name;
        }
    
        public virtual void IsDrawn(Player player)
        {
            //overridden by subclasses
        }
    }
}
