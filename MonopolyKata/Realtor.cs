using System.Collections.Generic;
using MonopolyKata.PropertySquares;

namespace MonopolyKata
{
    public class Realtor
    {

        private Dictionary<Square, Player> ownership; 

        public Realtor()
        {
            ownership = new Dictionary<Square, Player>();
        }

        public void Mortgage(Property property)
        {
            property.IsMortgaged = true;
        }

        public void UnMortgage(Property property)
        {
            property.IsMortgaged = false;
        }

        public void SetOwnerOf(Property property, Player player)
        {
            ownership[property] = player;
        }

        public Player GetOwnerOf(Property property)
        {
            return ownership.ContainsKey(property) ? ownership[property] : null;
        }
    }

}
