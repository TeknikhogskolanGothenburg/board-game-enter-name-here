using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Game
    {
        //Main Game object, everything is controlled through this object.

        public int GameId { get; set; }
        public string Name { get; set; }
        public List<Player> Players = new List<Player>();
        public Player CurrentPlayer { get; set; }

        public Dice Dice { get; set; }



        public Game(NameValueCollection form)
        {

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
            var p = new Player
            {
                Name = name,
                Email = email,
                ColorId = colorId
            };

            //ordna Players[] efter colorId så turordningen blir rätt.

            Players.Add(p);

        }
    }
}
