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
        private int _result;
        public int Result
        {
            get
            {
                return _result;
            }
        }


        public void RollDice()
        {
            Random random = new Random();
            int value = random.Next(Settings.Ludo["DiceMinValue"], Settings.Ludo["DiceMaxValue"]);

            _result = value;
        }
    }
}
