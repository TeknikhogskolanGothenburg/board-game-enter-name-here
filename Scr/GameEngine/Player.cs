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

        public Player()
        {
            Bricks = GeneratePlayerBricks();
        }


        private List<Brick> GeneratePlayerBricks()
        {
            var bricks = new List<Brick>();
            for (int i = 0; i < Settings.NoPlayerBricks; i++)
            {
                bricks.Add(new Brick
                {
                    Id = i,
                    ColorId = this.ColorId,
                    Position = Settings.ColorHomePosition[this.ColorId]
                });
                
            }
            return bricks;
        }

        //public Player(string Name, string Email)
        //{

        //}
    }
}
