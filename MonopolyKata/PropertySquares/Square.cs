using System;

namespace MonopolyKata.PropertySquares
{
    public class Square
    {
        public String Name;

        public Square(string nm)
        {
            Name = nm;
        }

        public virtual void IsLandedOn(Player player)
        {
            //Overriden by subclasses
        }

        public virtual void IsPassedBy(Player player)
        {
            //Overridden by go
        }
    }
}
