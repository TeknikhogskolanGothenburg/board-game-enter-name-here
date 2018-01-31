using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GameEngine.Helpers
{
    public static class GameHelper
    {
        public static Dictionary<int, Game> AllGames = new Dictionary<int, Game>();


        public static bool GameExists(int gameId)
        {
            if (AllGames.ContainsKey(gameId))
            {
                return true;
            }
            return false;
        }

        public static Game GetGameById(int id)
        {
            if (GameExists(id))
            {
                return AllGames[id];
            }
            return null;
        }

        public static Game GetGameById(int id, string gid)
        {
            if (GameExists(id) && Guid.TryParse(gid, out Guid GId))
            {
                if (AllGames[id].GId == GId)
                {
                    return AllGames[id];
                }
            }
            return null;
        }



        public static Player GetPlayerById(int id, Game game)
        {
            foreach (Player p in game.Players)
            {
                if (id == p.ColorId)
                {
                    return p;
                }
            }
            return null;
        }

        public static List<int> GetFreeHomeIds(int playerId, Game game)
        {
            var list = new List<int>();
            foreach (Player p in game.Players)
            {
                foreach ( Brick b in p.Bricks)
                {
                    if(b.Position >= Settings.PlayerHomePosition[playerId]) {
                        list.Add(b.Position);
                    }
                }

            }

            for (int i = Settings.PlayerHomePosition[playerId]; i > Settings.PlayerHomePosition[playerId]+4;i++)
            {
                if(list.Contains(i))
                {
                    list.Remove(i);

                }
            }

            return list;
        }
        public static int GetNextGameId()
        {
            if (AllGames.Count() == 0)
            {
                return Settings.GameMinId;
            }
            else
            {
                var newId = AllGames.Keys.Last() + 1;
                return newId;
            }
        }

        public static int GetColorId(string color)
        {
            int colorId;
            color = color.ToLower();
            if (Settings.ColorId.Values.Contains(color))
            {
                colorId = Settings.ColorId.FirstOrDefault(x => x.Value == color).Key;
                return colorId;
            }
            return -1;
        }

        public static Dictionary<int, Game> GetAllOpenGames()
        {
            var list = new Dictionary<int, Game>();

            foreach (int key in AllGames.Keys)
            {
                var game = AllGames[key];
                if (game.NoPlayers > game.Players.Count())
                {
                    list.Add(key, game);
                }
            }

            return list;
        }


    }
}
