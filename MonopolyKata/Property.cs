using System;

namespace MonopolyKata
{
    public class Property
    {

        public readonly String Name;

        public Property(String nm)
        {
            Name = nm;
        }

        public virtual void IsLandedOn(Player player)
        {
            //ToDo Later
        }

        public virtual void IsPassedBy(Player player)
        {
            //Overridden by go
        }


    }
}
