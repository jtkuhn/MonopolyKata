using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Property
    {

        public readonly String Name;
        public readonly int Position;

        public Property(String nm, int pos)
        {
            Name = nm;
            Position = pos;
        }

        public virtual void LandsOn(Player player)
        {
            
        }


    }
}
