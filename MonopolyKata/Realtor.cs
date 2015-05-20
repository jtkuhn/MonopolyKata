using System;

namespace MonopolyKata
{
    public class Realtor
    {
        private Player[] propertyOwners;
        private Property[] properties;
        private Board board;

        public Realtor(Board board)
        {
            propertyOwners = new Player[board.Size];
            this.board = board;
            properties = new Property[board.Size];
            InitializeProperties();
        }

        private void InitializeProperties()
        {
            for (int i = 0; i < board.Size; i++)
            {
                properties[i] = board.GetPropertyAt(i);
            }
        }

        public void SetOwner(Property property, Player player)
        {
            int location = Array.IndexOf(properties, property);
            propertyOwners[location] = player;
        }

        public Player GetOwner(Property property)
        {
            int location = Array.IndexOf(properties, property);
            return propertyOwners[location];
        }


    }

}
