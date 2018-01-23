using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ludo.Models.ViewModels
{
    public class NewGameViewModel
    {
        public string Name;
        public int noPlayers;
    }

    public class JoinGameViewModel
    {
        public List<GameEngine.Game> Games = new List<GameEngine.Game>();
    }
}