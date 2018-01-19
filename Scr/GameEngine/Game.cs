using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Game
    {

        //Main Game object, everything is controlled through this object.

        public int GameId { get; set; }
        public List<Player> Players = new List<Player>();
        public Player CurrentPlayer { get; set; }

        public Dice Dice { get; set; }



        public Game(NameValueCollection form)
        {

        }

    }
}
