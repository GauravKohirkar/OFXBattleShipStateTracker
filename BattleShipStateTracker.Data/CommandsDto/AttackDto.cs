using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipStateTracker.Data.CommandsDto
{
    public class AttackDto
    {
        public int PlayerId { get; set; }
        public int BoardId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
