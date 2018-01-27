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
        public Guid GId { get; set; }
        public string Name { get; set; }
        public List<Player> Players = new List<Player>();
        public Player CurrentPlayer { get; set; }
        public int CurrentTurn { get; set; } = 0;

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




        public Game()
        {
            Dice = new Dice();
            GameId = GameHelper.GetNextGameId();
            GId = Guid.NewGuid();
        }

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

                }
                return true;

            }
            return false;
        }


        public void UpdateGameMove(int playerId, int brickId)
        {

            var brick = Players[playerId].Bricks[brickId];
            var newPos = brick.PossibleNewPosition;
            var occupiedBy = IsPositionOccupied(newPos);

            brick.MoveToNewPosition(occupiedBy);

        }

        public void StartGame()
        {
            var result = 0;
            foreach(Player p in Players)
            {
                Dice.RollDice();
                if (Dice.Result > result)
                {
                    CurrentPlayer = p;
                }
            }
            CurrentTurn++;
            UpdatePossibleMoves();

        }


        public void NextTurn()
        {
            Dice.RollDice();
            CurrentPlayer = GetNextPlayer();
            CurrentTurn++;

            UpdatePossibleMoves();
        }



        public void AddPlayer(string name, string email, int colorId)
        {
            if (!IsFullGame())
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

        public bool IsFullGame()
        {
            return (Players.Count() == NoPlayers);
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



        private Brick IsPositionOccupied(int position)
        {
            //persons.Where(p => p.Appearance
            //    .Where(a => listOfSearchedIds.Contains(a.Id))
            //    .Any()).ToList();

            foreach (Player p in Players)
            {
                foreach (Brick b in p.Bricks)
                {
                    if (b.Position == position)
                    {
                        return b;
                    }
                }
            }

            return null;
        }

        private Player GetNextPlayer()
        {
            var currentIndex = Players.IndexOf(CurrentPlayer);
            var lastIndex = Players.IndexOf(Players.Last());

            var nextPlayer = CurrentPlayer;
            var i = currentIndex;

            while (nextPlayer == CurrentPlayer)
            {

                if (i == lastIndex)
                {
                    i = -1;
                }

                if (!Players[i + 1].IsFinished && !((i + 1) > lastIndex))
                {
                    nextPlayer = Players[i + 1];

                }

                i++;
            }

            return nextPlayer;

        }

        private void UpdatePossibleMoves()
        {
            foreach (Brick b in CurrentPlayer.Bricks)
            {
                var pos = b.GetNewPosition(Dice.Result);
                var occupiedBy = IsPositionOccupied(pos);

                b.CanMoveToPosition(pos, occupiedBy);
            }
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

        public void LeaveGame(int playerId)
        {
            //maybe send obj Player instead of Id
        }

        public void EndGame()
        {
            GameHelper.AllGames.Remove(this.GameId);
        }
    }
}
