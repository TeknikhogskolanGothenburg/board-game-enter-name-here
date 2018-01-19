using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Player
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Brick> Bricks = new List<Brick>();

        public Player()
        {

        }

        //public Player(string Name, string Email)
        //{

        //}
    }
}
