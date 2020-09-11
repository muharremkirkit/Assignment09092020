using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment09092020
{
    public interface ITile
    {
        public int getId(Tile t);

        public int getValue(Tile t);

        public Colors getColor(Tile t);

    }
}
