using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Player
    {

        public int ColorId { get; set; }
        public string Name = "Superman";
        public string Email { get; set; }
        public List<Brick> Bricks = new List<Brick>();
        public bool IsFinished { get; set; }
        public int FinalPosition { get; set; }

        public Player()
        {
            
        }

        //public Player(string Name, string Email)
        //{

        //}
    }
}
