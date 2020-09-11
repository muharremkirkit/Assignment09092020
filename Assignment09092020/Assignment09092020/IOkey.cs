using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment09092020
{
   public interface IOkey
    {
        public List<Tile> TasOlustur();
        public List<Tile> TaslariKaristir(List<Tile> Tiles);
        public (List<Player>, List<Tile>) TaslariDagit(List<Player> players, List<Tile> tiles);
        public (List<Player>, List<Tile>) GostergeVeOkey(List<Tile> tiles, List<Player> players);
        public List<Player> KazanmaIhtimaliOlanOyuncu(List<Player> players);
    }
}
