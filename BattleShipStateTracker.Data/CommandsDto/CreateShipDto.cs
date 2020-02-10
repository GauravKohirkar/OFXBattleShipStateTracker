using BattleShipStateTracker.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipStateTracker.Data.CommandsDto
{
    public class CreateShipDto
    {
        public int BoardId { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int ShipLength { get; set; }
        public BattleShipOrientation Orientation { get; set; }
    }
}
