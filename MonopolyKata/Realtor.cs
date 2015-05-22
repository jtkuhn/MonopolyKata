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
            this.board = board;
            propertyOwners = new Player[board.Size];
            properties = new Property[board.Size];
            InitializeProperties();
        }

        private void InitializeProperties()
        {
            for (var i = 0; i < board.Size; i++)
            {
                properties[i] = board.GetPropertyAt(i);
            }
        }

        public void SetOwnerOf(Property property, Player player)
        {
            var location = Array.IndexOf(properties, property);
            propertyOwners[location] = player;
        }

        public Player GetOwnerOf(Property property)
        {
            var location = Array.IndexOf(properties, property);
            return propertyOwners[location];
        }


    }

}
