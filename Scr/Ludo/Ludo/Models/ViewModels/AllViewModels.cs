using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public List<SelectListItem> Games = new List<SelectListItem>();
        public string GameIdDD { get; set; }
        public int GameId { get; set; }
        public GameEngine.Game Game { get; set; }
        public List<SelectListItem> Colors = new List<SelectListItem>();
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