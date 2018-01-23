using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameEngine.Helpers
{
    public static class GameHelper
    {
        public static List<Game> AllGames = new List<Game>();

        public static int GetNextGameId()
        {
            if (AllGames.Count() == 0)
            {
                return Settings.GameMinId;
            } else
            {
                var newId = AllGames.Count() + 1;
                return newId;
            }
        }
    }
}
