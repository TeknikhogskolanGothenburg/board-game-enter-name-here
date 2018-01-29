using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Helpers;

namespace GameEngine
{
    public class Player
    {

        public int ColorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Brick> Bricks = new List<Brick>();
        public bool IsFinished { get; set; } = false;
        public int FinalPosition { get; set; }

        //public Player()
        //{
        //    Bricks = GeneratePlayerBricks();
        //}

        public void GeneratePlayerBricks()
        {
            var bricks = new List<Brick>();
            for (int i = 0; i < Settings.NoPlayerBricks; i++)
            {
                bricks.Add(new Brick
                {
                    Id = i,
                    ColorId = ColorId,
                    Position = Settings.PlayerHomePosition[this.ColorId] + i
                });

            }
            Bricks = bricks;
        }

        public bool HasWon() {

            var list = new List<bool>();
            

            foreach(Brick b in Bricks)
            {
                if(b.Position >= Settings.PlayerFinalRowStart[ColorId] && b.Position < (Settings.PlayerFinalRowStart[ColorId] + Settings.NoPlayerBricks))
                {
                    list.Add(true);
                }
            }
            if (list.Count() > 0)
            {
                bool result = !list.Any(x => x == false);
                IsFinished = result;
                return result;
            }
            return false;
        }

        //private List<Brick> GeneratePlayerBricks()
        //{
        //    var bricks = new List<Brick>();
        //    for (int i = 0; i < Settings.NoPlayerBricks; i++)
        //    {
        //        bricks.Add(new Brick
        //        {
        //            Id = i,
        //            ColorId = ColorId,
        //            Position = Settings.PlayerHomePosition[this.ColorId] + i
        //        });

        //    }
        //    return bricks;
        //}

        //public Player(string Name, string Email)
        //{

        //}
    }
}
