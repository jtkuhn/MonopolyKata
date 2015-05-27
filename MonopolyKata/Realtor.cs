using System;
using MonopolyKata.PropertySquares;

namespace MonopolyKata
{
    public class Realtor
    {
        private Player[] propertyOwners;
        private Square[] properties;
        private Board board;

        public Realtor(Board board)
        {
            this.board = board;
            propertyOwners = new Player[board.Size];
            properties = new Square[board.Size];
            InitializeProperties();
        }

        private void InitializeProperties()
        {
            for (var i = 0; i < board.Size; i++)
            {
                properties[i] = board.GetSquareAt(i);
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
