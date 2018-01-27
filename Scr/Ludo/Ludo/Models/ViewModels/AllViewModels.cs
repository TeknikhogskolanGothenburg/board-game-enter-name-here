using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ludo.Models.ViewModels
{
    public class NewGameViewModel
    {
        public string Name { get; set; }
        public int NoPlayers { get; set; }
        public string PlayerName { get; set; }
        public string PlayerEmail { get; set; }
        public string PlayerColor { get; set; }
    }

    public class JoinGameListViewModel
    {
        public Dictionary<int, GameEngine.Game> Games = new Dictionary<int, GameEngine.Game>();
    }

    public class JoinGameViewModel
    {
        public Dictionary<int, GameEngine.Game> Games = new Dictionary<int, GameEngine.Game>();
        public int GameId { get; set; }
        public GameEngine.Game Game { get; set; }
        public string PlayerName { get; set; }
        public string PlayerEmail { get; set; }
        public string PlayerColor { get; set; }
    }

    public class _GameViewModel
    {
        public int BrickId { get; set; }
        public int PlayerId { get; set; }
        public bool Active { get; set; }

    }
}