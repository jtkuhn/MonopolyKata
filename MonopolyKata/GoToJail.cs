using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class GoToJail : Property
    {
        public GoToJail() : base("GoToJail", 30)
        {
        }

        public override void LandsOn(Player player)
        {
            player.Position = 10;
        }

    }
}
