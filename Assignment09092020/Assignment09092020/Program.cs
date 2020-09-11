using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment09092020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 35);
            Okey okey = new Okey();
            List<Player> Players = new List<Player>();
            List<Tile> Tiles = new List<Tile>();


            Players.Add(new Player(1, "Oyuncu1"));
            Players.Add(new Player(2, "Oyuncu2"));
            Players.Add(new Player(3, "Oyuncu3"));
            Players.Add(new Player(4, "Oyuncu4"));

            Tiles = okey.TasOlustur();

            Tiles = okey.TaslariKaristir(Tiles);

            (Players, Tiles) = okey.TaslariDagit(Players, Tiles);

            (Players, Tiles) = okey.GostergeVeOkey(Tiles, Players);

            Players = okey.KazanmaIhtimaliOlanOyuncu(Players);


            Console.WriteLine("*********  Oyuncu Skorları  *********\r\n");
            foreach (Player player in Players)
            {
                Console.WriteLine(String.Format("{0} Skoru: {1}", player.Name, player.kazanmaSansi));


                string taslar = "";
                foreach (var item in player.Tiles.OrderByDescending(z => z.Value))
                {
                    taslar += item.Color;
                    taslar += item.Value + " ";
                }
                Console.Write(String.Format("{0} taşları:( {1} )\r\n ", player.Name, taslar));
                Console.WriteLine("\r\n+++++++++++\r\n");
            }

            Console.WriteLine(String.Format("\r\n******** Kazanması muhtemel oyuncu: {0} skoru: {1}  ********", Players[3].Name, Players[3].kazanmaSansi));
            Console.ReadKey();
        }
    }
}
