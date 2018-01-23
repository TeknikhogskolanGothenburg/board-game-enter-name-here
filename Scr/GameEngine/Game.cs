﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Helpers;

namespace GameEngine
{
    public class Game
    {

        //Main Game object, everything is controlled through this object.

        public int GameId { get; set; }
        public string Name { get; set; }
        public List<Player> Players = new List<Player>();
        public Player CurrentPlayer { get; set; }

        public int NoPlayers;

        public Dice Dice { get; set; }

        public Game(NameValueCollection form)
        {
            GameId = GameHelper.GetNextGameId();
            Name = form["name"];
            GameHelper.AllGames.Add(this);
        }




        public bool JoinExistingGame(NameValueCollection form)
        {
            var name = form["name"];
            var email = form["email"];
            int colorId = 0;


            if (int.TryParse(form["colorId"], out int id))
            {
                colorId = id;
                try
                {
                    AddPlayer(name, email, colorId);
                }
                catch (Exception)
                {
                    //Ignore
                    Console.Write("Player could not be added.");
                }
                return true;

            }
            return false;
        }



        public void NextTurn()
        {

            var currentIndex = Players.IndexOf(CurrentPlayer);
            var lastIndex = Players.IndexOf(Players.Last());

            for (var i = currentIndex; i <= lastIndex; i++)
            {
                if (i == lastIndex)
                {
                    i = -1;
                }

                if (!Players[i + 1].IsFinished && !((i + 1) > lastIndex))
                {
                    CurrentPlayer = Players[i + 1];
                }
            }

            Dice.RollDice();
        }



        public void AddPlayer(string name, string email, int colorId)
        {
            if (Players.Count() < NoPlayers)
            {
                var p = new Player
                {
                    Name = name,
                    Email = email,
                    ColorId = colorId
                };
                Players.Add(p);
            }
            //ordna Players[] efter colorId så turordningen blir rätt.



        }


        public void EndGame()
        {
            GameHelper.AllGames.Remove(this);
        }
    }
}
