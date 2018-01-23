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

        // Need to remove set; from properties and instead use generators to set values.


        public int Id { get; set; }
        public int ColorId { get; set; }
        public int Position { get; set; }
        public bool IsSafe { get; set; } = false;
        public bool CanMove { get; set; } = false;
        public int PossibleNewPosition { get; set; }

        public void CanMoveToPosition(int diceResult)
        {
            var newPos = Position + diceResult;
            var totalBlocks = Settings.MaxPosition;
            var totalBlocksIncFinal = Settings.MaxPosition + Settings.NoBlocksFinalRow;

            if (newPos < totalBlocks)
            {
                CanMove = true;
                PossibleNewPosition = newPos;                
            }
            else
            {
                if (newPos < totalBlocksIncFinal)
                {
                    //Set position in final row. Need IDs
                    //PossibleNewPosition = ??
                }
                else
                {
                    CanMove = false;
                }
                
            }
        }

        public void Capture(Brick brick)
        {
            if(!brick.IsSafe)
            {
                brick.Position = Settings.ColorHomePosition[brick.ColorId];
                brick.IsSafe = true;
            }
            
        }

        public bool MoveToNewPosition(Brick brick)
        {
            Position = PossibleNewPosition;

            return true;
        }

    }
}
