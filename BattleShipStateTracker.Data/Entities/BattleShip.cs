using BattleShipStateTracker.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipStateTracker.Data.Entities
{
    public class BattleShip
    {
        public BattleShip()
        {
            BattleShipCoordinates = new List<BattleShipCoordinate>();
        }
        public int BattleShipId { get; set; }
        public BattleShipOrientation orientation { get; set; }

        public Board Board { get; set; }
        public ICollection<BattleShipCoordinate> BattleShipCoordinates { get; set; }
    }
}
