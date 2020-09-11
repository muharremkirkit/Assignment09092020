using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment09092020
{
    public class Tile : ITile
    {
        public int Id;
        public Colors Color;
        public int Value;
        public bool okeyMi = false;
        public bool gostergeMi = false;
        public bool dagitildiMi = false;

        public Tile(int Id, Colors Color, int Value)
        {
            this.Id = Id;
            this.Color = Color;
            this.Value = Value;

        }

        public int getId(Tile t)
        {
            return t.Id;
        }
        public int getValue(Tile t)
        {
            return t.Value;
        }

        public Colors getColor(Tile t)
        {
            return t.Color;
        }
    }
}
