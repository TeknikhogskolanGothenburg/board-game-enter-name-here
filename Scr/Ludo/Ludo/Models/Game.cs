using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ludo.Models
{
    public class Game
    {
       public GameEngine.Game Instance { get; set; }
        public string noPlayers;
        public string name;
    }
}