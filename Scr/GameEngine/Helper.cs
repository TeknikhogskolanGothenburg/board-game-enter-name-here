using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Helper
{
    public static class Helper
    {

        public static readonly Dictionary<string, int> Settings = new Dictionary<string, int>()
        {
            { "StartPosition", 1 },
            { "TotalBlocks", 52 },
            { "NoSections", 4 },
            { "NoSectionBlocks", 13},
            { "MaxNoPlayers", 4 },
            { "MinNoPlayers", 2 },
            { "NoPlayerBricks", 4 },
            { "IdStartAt", 1},


        };

        
    }
}
