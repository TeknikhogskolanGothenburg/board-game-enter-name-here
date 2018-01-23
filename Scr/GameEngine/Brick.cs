using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Helpers;

namespace GameEngine
{
    public class Brick
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public bool IsSafe { get; set; }
        public bool CanMoveThisTurn { get; set; }
        public int CanMoveToPosition { get; set; }
        
        //public int _CanMoveToPosition(int diceResult)
        //{
        //    if ( Position + diceResult > Settings.Ludo["TotalBlocks"])
        //    {

        //    }
        //}
    }
}
