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
            var model = new JoinGameListViewModel
            {
                Games = GameHelper.GetAllOpenGames()
            };

            return View("Join", model);
        }


        [HttpPost]
        public ActionResult Join(JoinGameViewModel model)
        {

            var gameId = model.GameId;
            var game = GameHelper.AllGames[gameId];

            var name = model.PlayerName;
            var email = model.PlayerEmail;
            var color = model.PlayerColor;

            var colorId = GameHelper.GetColorId(color);
            game.AddPlayer(name, email, colorId);

            CookieHelper.SetArrayCookieValue("Game", "Id", game.GameId.ToString());
            CookieHelper.SetArrayCookieValue("Game", "Players", game.NoPlayers.ToString());
            CookieHelper.SetArrayCookieValue("Player", "Id", colorId.ToString());
            CookieHelper.SetArrayCookieValue("Player", "Name", name);

            return Redirect("/game/" + gameId);
        }


        [HttpGet]
        public ActionResult New()
        {
            var model = new NewGameViewModel();
            return View("New", model);
        }


        [HttpPost]
        public ActionResult New(NewGameViewModel model)
        {

            //Create new Game object
            var game = new GameEngine.Game
            {
                GameId = GameHelper.GetNextGameId(),
                Name = model.Name,
                NoPlayers = model.NoPlayers,
            };

            // Add player 1
            var color = model.PlayerColor;

            var colorId = GameHelper.GetColorId(color);
            game.AddPlayer(model.PlayerName, model.PlayerEmail, colorId);

            GameHelper.AllGames.Add(game.GameId, game);


            CookieHelper.SetArrayCookieValue("Game", "Id", game.GameId.ToString());
            CookieHelper.SetArrayCookieValue("Game", "Players", game.NoPlayers.ToString());

            return Redirect("/game/" + game.GameId);
        }


        

    }
}