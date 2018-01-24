using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ludo.Models;
using Ludo.Models.ViewModels;
using Ludo.Helpers;
using GameEngine.Helpers;

namespace Ludo.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Game(string gameId)
        {
            var id = int.Parse(gameId);

            return View("Game");
        }


        [HttpGet]
        public ActionResult Join()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Join(FormCollection form)
        {

            var id = int.Parse(form["gameId"]);
            var game = GameHelper.AllGames[id];

            var name = form["player_name"];
            var email = form["player_email"];
            var colorId = int.Parse(form["color_id"]);

            game.AddPlayer(name, email, colorId);

            CookieHelper.SetArrayCookieValue("Game", "Id", game.GameId.ToString());
            CookieHelper.SetArrayCookieValue("Game", "Players", game.NoPlayers.ToString());
            CookieHelper.SetArrayCookieValue("Player", "Id", colorId.ToString());
            CookieHelper.SetArrayCookieValue("Player", "Name", name);

            return Redirect("/game/" + id);
        }


        [HttpGet]
        public ActionResult New()
        {
            var model = new NewGameViewModel();
            return View("New", model);
        }


        [HttpPost]
        public ActionResult New(FormCollection form)
        {
            
            //Create new Game object
            var game = new GameEngine.Game
            {
                GameId = GameEngine.Helpers.GameHelper.GetNextGameId(),
                Name = form["name"],
                NoPlayers = int.Parse(form["no_players"]),

            };
            
            // Add player 1
            game.AddPlayer(form["player_name"], form["player_email"], int.Parse(form["color_id"]));

            GameHelper.AllGames.Add(game.GameId, game);


            CookieHelper.SetArrayCookieValue("Game", "Id", game.GameId.ToString());
            CookieHelper.SetArrayCookieValue("Game", "Players", game.NoPlayers.ToString());

            return Redirect("/game/" + game.GameId);
        }
    }
}