using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settings = GameEngine.Helpers.Settings;

namespace GameEngine
{
    public class Dice
    {
        public int Result
        {
            get
            {
                return RollDice();
            }
        }


        private int RollDice()
        {

            Random random = new Random();
            int result = random.Next(Settings.Ludo["DiceMinValue"], Settings.Ludo["DiceMaxValue"]);
            
            return result;
        }
    }
}
