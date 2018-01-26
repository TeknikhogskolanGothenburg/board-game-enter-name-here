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
        public static readonly int GameMinId = 100;
        public static readonly int DiceMaxValue = 6;
        public static readonly int DiceMinValue = 1;

        public static readonly Dictionary<int,string> ColorId = new Dictionary<int,string>()
            {
                {0,"blue"},
                {1,"yellow"},
                {2,"red"},
                {3,"green"}
            };
        public static readonly Dictionary<int, int> ColorHomePosition = new Dictionary<int, int>()
            {
                {0, 1001 },
                {1, 1002 },
                {2, 1003 },
                {3, 1004 }
            };



    }
}
