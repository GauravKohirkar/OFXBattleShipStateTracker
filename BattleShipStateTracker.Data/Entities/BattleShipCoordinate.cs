using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipStateTracker.Data.Entities
{
    public class BattleShipCoordinate
    {
        public int BattleShipCoordinateId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsHit { get; set; }

        public BattleShip BattleShip { get; set; }
    }
}
