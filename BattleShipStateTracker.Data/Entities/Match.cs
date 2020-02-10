using System.Collections.Generic;

namespace BattleShipStateTracker.Data.Entities
{
    public class Match
    {
        public Match()
        {
            Boards = new List<Board>();
        }
        public int MatchId { get; set; }

        public ICollection<Board> Boards { get; set; }
    }
}
