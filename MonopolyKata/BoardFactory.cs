﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class BoardFactory
    {
        public Board Create()
        {
            return new Board();
        }
    }
}
