using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class RailroadSquare : Property
    {
        public RailroadSquare(string nm) : base(nm, 200, 25)
        {
        }

        public override void IsLandedOn(Player player)
        {
            if (owner != null)
            {
                int rentToBePaid = rent * (int)Math.Pow(2, owner.GetNumberOfRailroads() - 1);
                player.Money -= rentToBePaid;
                owner.Money += rentToBePaid;
            }
            else
            {
                player.Money -= cost;
                owner = player;
            }
        }
    }
}
