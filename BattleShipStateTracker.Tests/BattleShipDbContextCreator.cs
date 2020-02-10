using BattleShipStateTracker.Data.Data;
using BattleShipStateTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipStateTracker.Tests
{
    public class BattleShipDbContextCreator
    {
        public static BattleShipDbContext Create()
        {
            var config = new DbContextOptionsBuilder<BattleShipDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var _battleShipDbContext = new BattleShipDbContext(config);
            _battleShipDbContext.Database.EnsureCreated();
            var match = new Match() { MatchId = 1 };
            _battleShipDbContext.Matches.Add(match);
            var board = new Board()
            {
                Match = match,
                X = 10,
                Y = 10
            };
            _battleShipDbContext.Boards.Add(board);
            var bs = new BattleShip() { Board = board };
            _battleShipDbContext.BattleShips.Add(bs);
            _battleShipDbContext.BattleShipCoordinates.Add(new BattleShipCoordinate() { BattleShip = bs, X = 2, Y = 2 });
            _battleShipDbContext.BattleShipCoordinates.Add(new BattleShipCoordinate() { BattleShip = bs, X = 2, Y = 3 });
            _battleShipDbContext.SaveChanges();
            return _battleShipDbContext;
        }
        public static void Destroy(BattleShipDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
