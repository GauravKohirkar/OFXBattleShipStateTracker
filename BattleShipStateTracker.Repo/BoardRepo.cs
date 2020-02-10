using BattleShipStateTracker.Data.Data;
using BattleShipStateTracker.Data.Entities;
using BattleShipStateTracker.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipStateTracker.Repo
{
    public class BoardRepo : IBoardRepo
    {
        private readonly BattleShipDbContext _battleShipDbContext;
        public BoardRepo(BattleShipDbContext battleShipDbContext)
        {
            _battleShipDbContext = battleShipDbContext;
        }
        public async Task<Board> SetBoard(Match match, int SizeX, int SizeY)
        {
            var entity = new Board()
            {
                Match = match,
                X = SizeX,
                Y = SizeY
            };
            await _battleShipDbContext.Boards.AddAsync(entity);

            await _battleShipDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
