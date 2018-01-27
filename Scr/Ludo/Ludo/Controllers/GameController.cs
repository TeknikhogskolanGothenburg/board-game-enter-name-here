﻿using System;
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

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Game(int id)
        {
            var model = new GameModel();

            try
            {
                if (GameHelper.GameExists(id))
                {
                    model.GameId = id;
                    model.Game = GameHelper.GetGameById(id);
                    model.Game.CurrentPlayer = model.Game.Players[0];
                }

                if (model.Game.IsFullGame() && model.Game.CurrentTurn == 0)
                {
                    model.Game.StartGame();
                    UpdateBrickList(model);
                }
                else //if(model.Game.CurrentTurn > 0)
                {
                    UpdateBrickList(model);
                }

            }
            catch (Exception)
            {
                throw new HttpException(404, "Page not found");
            }

            return View("Game", model);
        }

        public ActionResult _Game(int bId, int pId, bool active)
        {
            var model = new _GameViewModel
            {
                BrickId = bId,
                PlayerId = pId,
                Active = active
            };

            return PartialView("_Game", model);
        }

        [HttpGet]
        public ActionResult Join()
        {
            var model = new JoinGameViewModel
            {
                Games = Helper.GetAllOpenGamesAsListItem()
                //Colors = Helper.GetAvailableColors();
            };

            return View("Join", model);
        }


        [HttpPost]
        public ActionResult Join(JoinGameViewModel model)
        {
            int gameId;

            if (int.TryParse(model.GameIdDD, out int gId))
            {
                gameId = gId;
            }
            else if (model.GameId != 0)
            {
                gameId = model.GameId;
            }
            else {
                return RedirectToAction("Join");
            }

            
            var game = GameHelper.AllGames[gameId];

            var name = model.PlayerName;
            var email = model.PlayerEmail;
            var color = model.PlayerColor;

            var colorId = GameHelper.GetColorId(color);
            game.AddPlayer(name, email, colorId);

            CookieHelper.SetArrayCookieValue("Game", "Id", game.GameId.ToString());
            CookieHelper.SetArrayCookieValue("Game", "GId", game.GId.ToString());
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
                Name = model.Name,
                NoPlayers = model.NoPlayers,
            };

            // Add player 1
            var color = model.PlayerColor;

            var colorId = GameHelper.GetColorId(color);
            game.AddPlayer(model.PlayerName, model.PlayerEmail, colorId);

            GameHelper.AllGames.Add(game.GameId, game);


            CookieHelper.SetArrayCookieValue("Game", "Id", game.GameId.ToString());
            CookieHelper.SetArrayCookieValue("Game", "GId", game.GId.ToString());
            CookieHelper.SetArrayCookieValue("Game", "Players", game.NoPlayers.ToString());
            CookieHelper.SetArrayCookieValue("Player", "Id", colorId.ToString());
            CookieHelper.SetArrayCookieValue("Player", "Name", model.PlayerName);


            //return View("New", model);
            return RedirectToRoute("Game", new { id = game.GameId.ToString() });
        }


        [HttpGet]
        public ActionResult Move(int playerId, int brickId)
        {
            var model = new GameModel
            {
                GameId = CookieHelper.GetGameId(),
                Game = CookieHelper.GetGameByCookie(),
            };

            model.Game.UpdateGameMove(playerId, brickId);
            model.Game.NextTurn();



            return View("Game", model);
        }

        private void UpdateBrickList(GameModel model)
        {

            var brickPos = new Dictionary<int, int>();

            //string html = $@"<div class=""marker - container"">
            //                    <a href=""{0}"">   
            //                        <div class=""player-head""></div>
            //                        <div class=""player-body""></div>
            //                        <div class=""player-foot""></div>
            //                    </a>
            //                </div>", Url.Action("Move", new { playerId = playerColorId, brickId = i });

            var playerColorId = CookieHelper.GetPlayerColorId();

            var active = false;

            if (model.Game.CurrentPlayer.ColorId == CookieHelper.GetPlayerColorId())
            {

                foreach (GameEngine.Player p in model.Game.Players)
                {
                    foreach (GameEngine.Brick b in p.Bricks)
                    {
                        brickPos.Add(b.Position, b.Id);
                        if (model.Game.CurrentPlayer == p)
                        {
                            active = true;
                        }
                        else
                        {
                            active = false;
                        }
                        model.Active.Add(b.Position, active);
                    }

                }

                for (int i = 1; i <= 1016; i++)
                {

                    if (brickPos.ContainsKey(i))
                    {
                        model.Bricks.Add(i, brickPos[i]);
                    }
                    else
                    {
                        model.Bricks.Add(i, -1);
                    }

                    if (!model.Active.ContainsKey(i))
                    {
                        model.Active.Add(i, false);
                    }

                    if (i == Settings.MaxPosition)
                    {
                        i = Settings.PlayerFinalRowStart[0] - 1;
                    }
                    else if (i == 116)
                    {
                        i = Settings.PlayerHomePosition[0] - 1;
                    }

                }
            }
        }

    }
}