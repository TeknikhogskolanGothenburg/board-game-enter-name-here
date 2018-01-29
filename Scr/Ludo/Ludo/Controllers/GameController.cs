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

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Game(int id, bool next = false)
        {
            var model = new GameModel();

            try
            {
                if (GameHelper.GameExists(id))
                {
                    model.GameId = id;
                    model.Game = GameHelper.GetGameById(id);
                    // model.Game.CurrentPlayer = model.Game.Players[0];
                }

                if (model.Game.HasWon() != null)
                {
                    model.StatusMessage = @"Player " + model.Game.CurrentPlayer.Name + "has won!";
                    UpdateBrickList(model, true);
                }
                else if (model.Game.IsFullGame() && model.Game.CurrentTurn == 0)
                {
                    model.Game.StartGame();
                    UpdateBrickList(model);
                }
                else if (next)
                {
                    model.Game.NextTurn();
                    UpdateBrickList(model);
                }
                else
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

        public ActionResult Skip()
        {
            var model = new GameModel
            {
                GameId = CookieHelper.GetGameId(),
                Game = CookieHelper.GetGameByCookie(),
            };
                        
            model.Game.NextTurn();

            return RedirectToAction("Game", "Game", new { id = model.GameId });
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
            else
            {
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
            //UpdateBrickList(gameModel);

            //return RedirectToRoute("Game", new { id = game.GameId });
            return RedirectToAction("Game", "Game", new { id = game.GameId });
            
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


            return RedirectToAction("Game", "Game", new { id = model.GameId });
            //return View("Game", model);
        }

        private void UpdatePlayerDiceinfo(GameModel model)
        {
            var playerName = new Dictionary<int, string>();
            var diceResult = new Dictionary<int, int>();

            var players = model.Game.Players;
            var count = players.Count();

            for (int i = 0; i < Settings.MaxNoPlayers; i++)
            {
                if (count >= i)
                {
                    var player = players[i];

                    playerName.Add(player.ColorId, player.Name);
                    if (player == model.Game.CurrentPlayer)
                    {
                        diceResult.Add(player.ColorId, model.Game.Dice.Result);
                    }
                    else
                    {
                        diceResult.Add(player.ColorId, 0);
                    }
                }
                else
                {

                }

            }
        }
        /*
         * Puts all game marker's / brick's positions and Id:s in dictionaries for print out in Game View.
         */
        private void UpdateBrickList(GameModel model, bool isFinished = false)
        {

            var brickPos = new Dictionary<int, int>();
            var playerPosIdList = new Dictionary<int, int>();
            var playerName = model.PlayerName;
            var diceResult = model.DiceResult;

            var currentPlayer = model.Game.CurrentPlayer;
            var player = CookieHelper.GetPlayer();

            var active = false;


            foreach (GameEngine.Player p in model.Game.Players)
            {
                foreach (GameEngine.Brick b in p.Bricks)
                {
                    brickPos.Add(b.Position, b.Id);
                    playerPosIdList.Add(b.Position, p.ColorId);
                    if (p == currentPlayer && player == currentPlayer && b.CanMove)
                    {
                        active = true;
                        model.StatusMessage = "";
                    }
                    else
                    {
                        active = false;
                        var url = Url.Action("Skip", "Game", new {});
                        if (!model.Game.IsFullGame())
                        {
                            model.StatusMessage = "Waiting for players";
                        }
                        else if (player == currentPlayer)
                        {
                            model.StatusMessage = $@"Can't move, <a href=""{url}"">next player</a>";
                        } else
                        {
                            model.StatusMessage = "Waiting for " + currentPlayer.Name;
                        }


                    }
                    model.Active.Add(b.Position, active);
                }

                playerName.Add(p.ColorId, p.Name);
                if (p == currentPlayer)
                {
                    diceResult.Add(p.ColorId, p.Name + " rolls a " + model.Game.Dice.Result);
                }
                else
                {
                    diceResult.Add(p.ColorId, "");
                }

            }

            for (int i = 0; i < Settings.MaxNoPlayers; i++)
            {
                if (!playerName.ContainsKey(i))
                {
                    playerName.Add(i, "");
                }
                if (!diceResult.ContainsKey(i))
                {
                    diceResult.Add(i, "");
                }
            }

            for (int i = 1; i <= 1016; i++)
            {

                if (brickPos.ContainsKey(i))
                {
                    model.Bricks.Add(i, brickPos[i]);
                    model.PlayerPosId.Add(i, playerPosIdList[i]);
                }
                else
                {
                    model.Bricks.Add(i, -1);
                    model.PlayerPosId.Add(i, -1);
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

            if (isFinished)
            {
                var keys = new List<int>(model.Active.Keys);
                foreach (int key in keys)
                {
                    model.Active[key] = false;
                }

            }

        }

    }
}