using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Player
    {
        private Random rand = new Random();

        public Player()
        {
            Position = 0;
        }

        public int Position { get; set; }

        public void Move(int x)
        {
            Position += x;
            Position %= 40;
        }


    }
}
