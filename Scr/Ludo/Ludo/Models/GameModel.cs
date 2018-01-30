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
        public Dictionary<int, string> PlayerName = new Dictionary<int, string>();
        public Dictionary<int, string> DiceResult = new Dictionary<int, string>();
        public string StatusMessage;
    }
}