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
        public static readonly int MaxPosition = 44;
        public static readonly int MaxSteps = 42;
        public static readonly int NoBlocksFinalRow = 4;
        public static readonly int NoSections = 4;
        public static readonly int NoSectionBlocks = 11;
        public static readonly int MaxNoPlayers = 4;
        public static readonly int MinNoPlayers = 2;
        public static readonly int NoPlayerBricks = 4;
        public static readonly int GameMinId = 100;
        public static readonly int DiceMaxValue = 6;
        public static readonly int DiceMinValue = 1;

        public static readonly Dictionary<int, string> ColorId = new Dictionary<int, string>()
            {
                {0, "blue"},
                {1, "yellow"},
                {2, "red"},
                {3, "green"}
            };
        public static readonly Dictionary<int, int> PlayerHomePosition = new Dictionary<int, int>()
            {
                {0, 1001 },
                {1, 1005 },
                {2, 1009 },
                {3, 1013 }
            };
        public static readonly Dictionary<int, int> PlayerStartPosition = new Dictionary<int, int>()
            {
                {0, 8 },
                {1, 19 },
                {2, 30 },
                {3, 41 }
            };
        public static readonly Dictionary<int, int> PlayerEndPosition = new Dictionary<int, int>()
            {
                {0, 6 },
                {1, 17 },
                {2, 28 },
                {3, 39 }
            };
        public static readonly Dictionary<int, int> PlayerFinalRowStart = new Dictionary<int, int>()
            {
                {0, 101 },
                {1, 105 },
                {2, 109 },
                {3, 113 }
            };



    }
}
