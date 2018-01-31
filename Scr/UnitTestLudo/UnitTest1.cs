using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameEngine;
using GameEngine.Helpers;
using System.Collections.Generic;

namespace UnitTestLudo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateGameTest()
        {

            var game = new Game
            {
                Name = "Game test",
                NoPlayers = 2
            };

            
            var game2 = new Game
            {
                Name = "Game test 2",
                NoPlayers = 4
            };

            Assert.AreEqual(100, game.GameId);
            Assert.AreEqual(101, game2.GameId);
            Assert.AreNotEqual(game.GId, game2.GId);
            Assert.AreSame(game, GameHelper.AllGames[game.GameId]);

        }


        [TestMethod]
        public void AddPlayerTest()
        {
            var game = new Game
            {
                Name = "Game test",
                NoPlayers = 2
            };

            game.AddPlayer("Player 1", "mail@mail.com", 0);
            game.AddPlayer("Player 2", "mail2@mail.com", 3);

            Assert.AreEqual(2, game.Players.Count);
            
        }

        [TestMethod]
        public void PlayerPositionCalculation()
        {

            var dice = 4;

            var game = new Game
            {
                Name = "Game test",
                NoPlayers = 2,
            };

            game.AddPlayer("Player 1", "mail@mail.com", 0);
            //game.AddPlayer("Player 2", "mail2@mail.com", 3);

            game.Players[0].Bricks[0].Position = 43;
            game.Players[0].Bricks[0].StepsTaken = 2;
            var pos = game.Players[0].Bricks[0].GetNewPosition(4);
            game.Players[0].Bricks[0].CanMoveToPosition(pos, dice);
            var list = new List<int>();
            game.Players[0].Bricks[0].MoveToNewPosition(list);
            var newPos = game.Players[0].Bricks[0].Position;

            Assert.IsTrue(game.Players[0].Bricks[0].CanMove);
            Assert.AreEqual(3, pos);
            Assert.AreEqual(3, newPos);


        }
    }
}
