using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameEngine.Helpers;

namespace Ludo.Helpers
{
    public static class Helper
    {

        public static List<SelectListItem> GetAllOpenGamesAsListItem()
        {
            var games = GameHelper.GetAllOpenGames();
            var list = new List<SelectListItem>();

            list.Add(new SelectListItem { Text = "Select game to join", Value = "" });
            foreach (var g in games)
            {
                var gameId = g.Value.GameId;
                var name = g.Value.Name;
                var players = g.Value.Players.Count();
                var maxPlayers = g.Value.NoPlayers;

                var text = $@"#{gameId}, {name}, {players} of {maxPlayers} players";
                list.Add(
                    new SelectListItem { Text = text, Value = gameId.ToString() }
                    );
            }

            return list;

        }
    }
}