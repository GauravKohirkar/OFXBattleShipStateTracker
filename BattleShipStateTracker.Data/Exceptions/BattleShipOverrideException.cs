using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipStateTracker.Data.Exceptions
{
    public class BattleShipOverrideException : Exception
    {
        public BattleShipOverrideException() : base($"Battle Ships are being overridden.")
        {

        }
    }
}
