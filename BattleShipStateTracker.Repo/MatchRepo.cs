using BattleShipStateTracker.Data.Data;
using BattleShipStateTracker.Data.Entities;
using BattleShipStateTracker.Repo.Interfaces;
using System;
using System.Threading.Tasks;

namespace BattleShipStateTracker.Repo
{
    public class MatchRepo : IMatchRepo
    {
        private readonly BattleShipDbContext _battleShipDbContext;
        public MatchRepo(BattleShipDbContext battleShipDbContext)
        {
            _battleShipDbContext = battleShipDbContext;
        }

        public async Task<int> CreateMatch()
        {
            var entity = new Match();
            await _battleShipDbContext.Matches.AddAsync(entity);
            await _battleShipDbContext.SaveChangesAsync();
            return entity.MatchId;
        }

        public async Task<Match> GetMatchById(int id)
        {
            return await _battleShipDbContext.Matches.FindAsync(id);
        }
    }
}
