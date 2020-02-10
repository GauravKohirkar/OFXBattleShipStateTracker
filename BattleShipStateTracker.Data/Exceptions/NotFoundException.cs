using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipStateTracker.Data.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string key, object val) : base($"Key: {key} ({val}) could not be found.")
        {
        }
    }
}
