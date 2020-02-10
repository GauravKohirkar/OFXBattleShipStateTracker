using BattleShipStateTracker.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipStateTracker.Tests
{
    public class TestBase : IDisposable
    {
        protected readonly BattleShipDbContext _battleShipDbContext;
        public TestBase()
        {
            _battleShipDbContext = BattleShipDbContextCreator.Create();
        }
        public void Dispose()
        {
            BattleShipDbContextCreator.Destroy(_battleShipDbContext);
        }
    }
}
