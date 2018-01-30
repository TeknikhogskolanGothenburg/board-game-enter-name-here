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
        public int ColorId { get; set; }
        public int Position { get; set; }
        public bool IsSafe { get; set; } = false;
        public bool CanMove { get; set; } = false;
        public int PossibleNewPosition { get; set; }
        public int StepsTaken = 0;

        
        public void CanMoveToPosition(int position, int diceResult, Brick brick = null)
        {
            //debug
            if (Position >= Settings.PlayerHomePosition[0] /*&& (diceResult == Settings.DiceMaxValue || diceResult == Settings.DiceMinValue)*/ && (brick == null || brick.ColorId != ColorId))
            {
                CanMove = true;
                PossibleNewPosition = position;
            }
            else if (brick == null || (brick.ColorId != ColorId && !brick.IsSafe))
            {
                CanMove = true;
                PossibleNewPosition = position;
            }
            else
            {
                CanMove = false;
            }
        }

        private void Capture(Brick brick)
        {
            if (!brick.IsSafe)
            {
                brick.Position = Settings.PlayerHomePosition[brick.ColorId];
                brick.IsSafe = true;
            }

        }

        public int GetNewPosition(int diceResult)
        {

            var newPos = Position + diceResult;
            var maxPos = Settings.MaxPosition;
            var totalBlocksIncFinal = Settings.MaxPosition + Settings.NoBlocksFinalRow;
            var endPos = Settings.PlayerEndPosition[ColorId];
            var steps = StepsTaken;

            var endRowStartPos = Settings.PlayerFinalRowStart[ColorId];
            var endRowEndPos = endRowStartPos + Settings.NoBlocksFinalRow - 1;

            int result = 0;
            //debug
            if (steps == 0 && Position >= Settings.PlayerHomePosition[ColorId] && Position <= Settings.PlayerHomePosition[ColorId] + 3 /*&& (diceResult == Settings.DiceMaxValue || diceResult == Settings.DiceMinValue)*/)
            {
                result = Settings.PlayerStartPosition[ColorId];
            }
            else if (steps > 0 && steps <= Settings.MaxSteps)
            {
                if (newPos < maxPos)
                {
                    result = newPos;
                }
                else
                {
                    result = newPos - maxPos;
                }
            }
            else
            {
                if (newPos - endPos <= Settings.NoBlocksFinalRow)
                {
                    result = (endRowStartPos - 1) + (newPos - endPos);
                }
                else if (newPos >= endRowStartPos && newPos <= endRowEndPos)
                {
                    result = newPos;
                }
                else
                {
                    result = Position;
                }

            }

            return result;

        }

        public bool MoveToNewPosition(Brick brick = null)
        {

            if (brick == null)
            {
                if (Position >= Settings.PlayerHomePosition[0])
                {
                    Position = Settings.PlayerStartPosition[ColorId];
                    IsSafe = true;
                    UpdateStepsTaken(1);
                }
                else
                {
                    UpdateStepsTaken();
                    Position = PossibleNewPosition;
                    if (Position > Settings.PlayerFinalRowStart[0])
                    {
                        IsSafe = true;
                    }
                    else
                    {
                        IsSafe = false;
                    }
                }
            }
            else
            {
                Capture(brick);
                UpdateStepsTaken();
                Position = PossibleNewPosition;
            }

            //needs attention, calculation is incorrect. if position is 43 then new position is 4, 

            return true;
        }

        private void UpdateStepsTaken(int? newValue = null)
        {
            if (newValue == null)
            {
                if (Position > 38 && PossibleNewPosition <= 1)
                {
                    StepsTaken += Settings.MaxPosition - Position;
                    StepsTaken += PossibleNewPosition - Settings.MinPosition;
                }
                else
                {
                    StepsTaken += PossibleNewPosition - Position;
                }
            }
            else
            {
                StepsTaken = int.Parse(newValue.ToString());
            }




        }

    }
}
