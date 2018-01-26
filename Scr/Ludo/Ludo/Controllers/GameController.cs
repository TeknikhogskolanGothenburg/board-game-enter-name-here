using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ludo.Models;
using Ludo.Models.ViewModels;
using Ludo.Helpers;
using GameEngine.Helpers;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Ludo.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Game(int id)
        {
            var model = new GameModel
            {
                GameId = id,
                Game = GameHelper.AllGames[id]
            };
            try
            {
                if (GameHelper.GameExists(id))
                {

                }
            }
            catch(Exception)
            {
                throw new HttpException(404, "Page not found");
            }
            
            

            return View("Game", model);
        }


        [HttpGet]
        public ActionResult Join()
        {
            var model = new JoinGameViewModel
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
            //model.Games = GameHelper.GetAllOpenGames();

            var gameModel = new GameModel
            {
                GameId = gameId,
                Game = game
            };


            return RedirectToRoute("Game", new { id = game.GameId });
            //return View("Game",gameModel);
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
            

            //return View("New", model);
            return RedirectToRoute("Game", new { id = game.GameId.ToString() });
        }

        [HttpGet]
        public ActionResult Move(GameModel model)
        {


            

            return View("Game", model);
        }



    }
}