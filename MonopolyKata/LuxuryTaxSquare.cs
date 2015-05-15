using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class LuxuryTaxSquare : Property
    {
        public LuxuryTaxSquare() : base("Luxury Tax")
        {
        }

        public override void IsLandedOn(Player player)
        {
            player.Money -= 75;
        }
    }
}
