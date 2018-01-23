using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Helpers
{
    public static class Settings
    {

        public static readonly int MinPosition = 1;
        public static readonly int MaxPosition = 52;
        public static readonly int NoBlocksFinalRow = 5;
        public static readonly int NoSections = 4;
        public static readonly int NoSectionBlocks = 13;
        public static readonly int MaxNoPlayers = 4;
        public static readonly int MinNoPlayers = 2;
        public static readonly int NoPlayerBricks = 4;
        public static readonly int GameMinId = 1;
        public static readonly int DiceMaxValue = 6;
        public static readonly int DiceMinValue = 1;

        public static readonly Dictionary<string, int> ColorId = new Dictionary<string, int>()
            {
                {"Blue", 0 },
                {"Yellow", 1 },
                {"Red", 2 },
                {"Green", 3 }
            };
        public static readonly Dictionary<int, int> ColorHomePosition = new Dictionary<int, int>()
            {
                {0, 1000 },
                {1, 2000 },
                {2, 3000 },
                {3, 4000 }
            };



    }
}
