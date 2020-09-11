using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment09092020
{
    public class Okey : IOkey
    {
        public List<Tile> TasOlustur()

        {
            List<Tile> Tiles = new List<Tile>();
            int countId = 0;
            for (int j = 0; j < 2; j++)
            {

                for (int i = 0; i < 13; i++)
                {
                    Tiles.Add(new Tile(countId, Colors.Sarı, i + 1));
                    countId++;
                }

                for (int i = 0; i < 13; i++)
                {
                    Tiles.Add(new Tile(countId, Colors.Mavi, i + 1));
                    countId++;
                }

                for (int i = 0; i < 13; i++)
                {
                    Tiles.Add(new Tile(countId, Colors.Siyah, i + 1));
                    countId++;

                }

                for (int i = 0; i < 13; i++)
                {
                    Tiles.Add(new Tile(countId, Colors.Kırmızı, i + 1));
                    countId++;

                }

                Tiles.Add(new Tile(countId, Colors.SahteOkey, -1));
                countId++;

            }

            return Tiles;
        }

        public List<Tile> TaslariKaristir(List<Tile> Tiles)
        {
            Random r = new Random();
            for (int i = Tiles.Count; i > 0; i--)
            {
                int j = r.Next(i);
                Tile k = Tiles[j];
                Tiles[j] = Tiles[i - 1];
                Tiles[i - 1] = k;
            }
            return Tiles;
        }

        public (List<Player>, List<Tile>) TaslariDagit(List<Player> players, List<Tile> tiles)
        {

            int count = 0;
            for (int j = 0; j < 4; j++)
            {

                for (int i = 0; i < 14; i++)
                {
                    players[j].Tiles.Add(tiles[count]);
                    tiles[count].dagitildiMi = true;
                    count++;
                }

            }

            Random rnd = new Random();
            int number = rnd.Next(0, 3);
            players[number].Tiles.Add(tiles[count]);
            tiles[count].dagitildiMi = true;

            return (players, tiles);
        }

        public (List<Player>, List<Tile>) GostergeVeOkey(List<Tile> tiles, List<Player> players)
        {
            Random rnd = new Random();
            var fakeRemovedTiles = tiles.Where(o => o.Color != Colors.SahteOkey & o.dagitildiMi == true).ToList();
            var fakeTile = fakeRemovedTiles[rnd.Next(fakeRemovedTiles.Count)];
            Console.WriteLine(String.Format("Gösterge : {0} {1}", fakeTile.Color, fakeTile.Value.ToString()));

            if (tiles.Where(o => o.Id == fakeTile.Id).Count() != 0)
                tiles.Where(o => o.Id == fakeTile.Id).First().gostergeMi = true;
            if (tiles.Where(o => o.Id != fakeTile.Id & o.Color == fakeTile.Color & o.Value == fakeTile.Value).Count() != 0)
                tiles.Where(o => o.Id != fakeTile.Id & o.Color == fakeTile.Color & o.Value == fakeTile.Value).Last().gostergeMi = true;

            if (fakeTile.Value == 13 & tiles.Where(o => o.Value == 1 & o.Color == fakeTile.Color).Count() != 0)
            {
                tiles.Where(o => o.Value == 1 & o.Color == fakeTile.Color).First().okeyMi = true;
                tiles.Where(o => o.Value == 1 & o.Color == fakeTile.Color).Last().okeyMi = true;
                Console.WriteLine(String.Format("Okey: {0} 1", fakeTile.Color));


            }
            else
            {
                if (tiles.Where(o => o.Value == fakeTile.Value + 1 & o.Color == fakeTile.Color).Count() != 0)
                {

                    tiles.Where(o => o.Value == fakeTile.Value + 1 & o.Color == fakeTile.Color).First().okeyMi = true;
                    tiles.Where(o => o.Value == fakeTile.Value + 1 & o.Color == fakeTile.Color).Last().okeyMi = true;
                    Console.WriteLine(String.Format("Okey: {0} {1}", fakeTile.Color, (fakeTile.Value + 1).ToString()));

                }

            }


            foreach (Player player in players)
            {
                if (player.Tiles.Where(o => o.Id == fakeTile.Id).Count() != 0)
                {
                    player.Tiles.Where(o => o.Id == fakeTile.Id).First().gostergeMi = true;
                    player.sahteOkeyVarMı = true;
                }

                if (fakeTile.Value == 13 & player.Tiles.Where(o => o.Value == 1 & o.Color == fakeTile.Color).Count() != 0)
                {
                    player.Tiles.Where(o => o.Value == 1 & o.Color == fakeTile.Color).First().okeyMi = true;
                    player.Tiles.Where(o => o.Value == 1 & o.Color == fakeTile.Color).Last().okeyMi = true;
                    player.okeySayısı += 1;
                    Console.WriteLine(String.Format("Okeyi olan oyuncu : {0}  ", player.Name));



                }
                else
                {
                    if (player.Tiles.Where(o => o.Value == fakeTile.Value + 1 & o.Color == fakeTile.Color).Count() != 0)
                    {
                        player.Tiles.Where(o => o.Value == fakeTile.Value + 1 & o.Color == fakeTile.Color).First().okeyMi = true;
                        player.Tiles.Where(o => o.Value == fakeTile.Value + 1 & o.Color == fakeTile.Color).Last().okeyMi = true;
                        player.okeySayısı += 1;
                        Console.WriteLine(String.Format("Okeyi olan oyuncu : {0}  ", player.Name));

                    }

                }


            }

            return (players, tiles);


        }

        public List<Player> KazanmaIhtimaliOlanOyuncu(List<Player> players)
        {

            foreach (Player player in players)
            {
                if (player.okeySayısı > 0)
                {
                    player.kazanmaSansi += player.okeySayısı * 5;
                }


                // ++++++++++++++++-----------------------------++++++++++++++++++++++
                List<Tile> tiles = new List<Tile>();
                foreach (var item in player.Tiles.OrderByDescending(o => o.Value))
                {
                    tiles.Add(item);
                }

                for (int i = 0; i < tiles.Count() - 2; i++)
                {
                    if (tiles[i].Value == tiles[i + 1].Value && tiles[i].Color != tiles[i + 1].Color &&
                        tiles[i].Value == tiles[i + 2].Value && tiles[i].Color != tiles[i + 2].Color && tiles[i + 1].Color != tiles[i + 2].Color)
                    {
                        player.kazanmaSansi += 2;
                    }
                }



                // ------------------------+++++++++++++++++++++------------------------------
                List<Tile> tilesColor = new List<Tile>();
                foreach (var item in player.Tiles.OrderBy(o => o.Value).OrderBy(z=>z.Color))
                {
                    tilesColor.Add(item);
                }

                for (int i = 0; i < tilesColor.Count(); i++)
                {
                    if (i + 2 < tilesColor.Count())
                    {
                        if (tilesColor[i].Color == tilesColor[i + 1].Color && tilesColor[i].Value + 1 == tilesColor[i + 1].Value &&
                       tilesColor[i].Color == tilesColor[i + 2].Color && tilesColor[i].Value + 2 == tilesColor[i + 2].Value)
                        {
                            player.kazanmaSansi += 2;
                        }
                    }


                }

                //-----------------------------************************-----------------------------
                List<Tile> tilesTwin = new List<Tile>();
                foreach (var item in player.Tiles.OrderByDescending(o => o.Value))
                {
                    tilesTwin.Add(item);
                }

                for (int i = 0; i < tilesTwin.Count() - 1; i++)
                {
                    if (tilesTwin[i].Value == tilesTwin[i + 1].Value && tilesTwin[i].Color == tilesTwin[i + 1].Color)
                    {
                        player.kazanmaSansi += 1;
                    }
                }

            }

            return players.OrderBy(o => o.kazanmaSansi).ToList();
        }
    }
}
