using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class IncomeTaxSquare : Property
    {
        public IncomeTaxSquare() : base("Income Tax")
        {
        }

        public override void IsLandedOn(Player player)
        {
            if (player.Money < 2000) player.Money -= player.Money/10;
            else player.Money -= 200;
        }
    }
}
