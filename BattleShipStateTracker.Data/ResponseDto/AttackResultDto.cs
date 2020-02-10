using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipStateTracker.Data.ResponseDto
{
    public class AttackResultDto
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsHit { get; set; }
    }
}
