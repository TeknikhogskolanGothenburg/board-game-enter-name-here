﻿using System;
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

        public static int GetNextGameId()
        {
            if (AllGames.Count() == 0)
            {
                return Settings.GameMinId;
            }
            else
            {
                var newId = AllGames.Count() + 1;
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
