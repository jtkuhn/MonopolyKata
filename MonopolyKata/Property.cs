using System;

namespace MonopolyKata
{
    public class Property
    {

        public String Name;
        public int cost;
        public int rent;

        public Property(string nm, int cost = 0, int rent = 0)
        {
            Name = nm;
            this.cost = cost;
            this.rent = rent;
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
