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
