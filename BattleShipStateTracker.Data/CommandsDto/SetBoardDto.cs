using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipStateTracker.Data.CommandsDto
{
    /// <summary>
    /// This Command Requires MatchId from the match started.
    /// </summary>
    public class SetBoardDto
    {
        private const int DEFAULT_SIZE = 10;
        public int MatchId { get; set; }
        public int SizeX { get; set; } = DEFAULT_SIZE;
        public int SizeY { get; set; } = DEFAULT_SIZE;
    }
}
