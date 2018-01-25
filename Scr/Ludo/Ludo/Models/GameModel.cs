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
        
    }
}