using System;

namespace MonopolyKata
{
    public class Property
    {
        public String Name;
        public Player owner;
        public int cost;
        public int rent;

        public Property(string nm, int cost = 0, int rent = 0)
        {
            Name = nm;
            this.cost = cost;
            this.rent = rent;
        }

        public void SetOwner(Player player)
        {
            owner = player;
        }

        public virtual void IsLandedOn(Player player)
        {
            if (owner != null)
            {
                player.Money -= rent;
                owner.Money += rent;
            }
            else
            {
                player.Money -= cost;
                owner = player;
            }
        }

        public virtual void IsPassedBy(Player player)
        {
            //Overridden by go
        }
    }
}
