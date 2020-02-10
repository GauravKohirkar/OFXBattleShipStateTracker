using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipStateTracker.Data.Entities
{
    public class Board
    {
        public Board()
        {
            BattleShips = new List<BattleShip>();
        }
        public int BoardId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Match Match { get; set; }
        public ICollection<BattleShip> BattleShips { get; set; }
    }
}
