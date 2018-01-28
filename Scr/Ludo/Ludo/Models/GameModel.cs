using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ludo.Models
{
    public class GameModel
    {   
        public int GameId { get; set; }
        public GameEngine.Game Game { get; set; }

        public Dictionary<int, int> Bricks = new Dictionary<int, int>();
        public Dictionary<int, int> PlayerPosId = new Dictionary<int, int>();        
        public Dictionary<int, bool> Active = new Dictionary<int, bool>();
        

    }
}