using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment09092020
{
    public class Player
    {
        public int Id;
        public string Name;
        public Player(int Id, string Name)
        {
            this.Name = Name;
            this.Id = Id;
        }

        public List<Tile> Tiles = new List<Tile>();
        public int kazanmaSansi { get; set; } = 0;
        public int okeySayısı { get; set; } = 0;
        public bool sahteOkeyVarMı { get; set; } = false;
    }
}
