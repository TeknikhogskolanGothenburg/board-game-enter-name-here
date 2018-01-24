using System;
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

        public List<int> TakenColorIds
        {
            get
            {
                return GetTakenColorIds();
            }
        }

        public Dice Dice { get; set; }

        //public Game(NameValueCollection form)
        //{
        //    GameId = GameHelper.GetNextGameId();
        //    Name = form["name"];
        //    GameHelper.AllGames.Add(this);
        //}




        public bool JoinExistingGame(string name, string email, int colorId)
        {
           

            if (!this.GetTakenColorIds().Contains(colorId))
            {
                
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

        public void LeaveGame(int playerId)
        {
            //maybe send obj Player instead of Id
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


        private List<int> GetTakenColorIds()
        {
            var takenIds = new List<int>();

            foreach (var p in Players)
            {
                takenIds.Add(p.ColorId);
            }

            return takenIds;
        }

        //public List<int> GetAvailableColorIds()
        //{
        //    var availableIds = new List<int>(Settings.ColorId.Keys);
        //    var takenIds = new List<int>();

        //    foreach (var p in Players)
        //    {
        //        takenIds.Add(p.ColorId);
        //    }

        //    availableIds = availableIds.Except(takenIds).ToList();

        //    return availableIds;

        //}


        public void EndGame()
        {
            GameHelper.AllGames.Remove(this.GameId);
        }
    }
}
