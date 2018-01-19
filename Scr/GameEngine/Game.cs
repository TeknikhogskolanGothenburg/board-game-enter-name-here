using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Helper;

namespace GameEngine
{
    public class Game
    {
        public int GameId { get; set; }
        public List<Player> Players = new List<Player>();
        public Player CurrentTurn { get; set; }




        public Game(NameValueCollection form)
        {
            
        }

    }
}
