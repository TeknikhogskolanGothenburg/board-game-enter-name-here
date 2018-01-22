using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Helpers
{
    public static class Settings
    {
        public static readonly Dictionary<string, int> Ludo = new Dictionary<string, int>()
        {
            { "StartPosition", 1 },
            { "TotalBlocks", 52 },
            { "NoSections", 4 },
            { "NoSectionBlocks", 13},
            { "MaxNoPlayers", 4 },
            { "MinNoPlayers", 2 },
            { "NoPlayerBricks", 4 },
            { "IdStartAt", 1 },
            { "DiceMaxValue", 6 },
            { "DiceMinValue", 1 },
            { "ColorId.Blue", 0 },
            { "ColorId.Yellow", 1 },
            { "ColorId.Red", 2 },
            { "ColorId.Green", 3 },


        };
    }
}
