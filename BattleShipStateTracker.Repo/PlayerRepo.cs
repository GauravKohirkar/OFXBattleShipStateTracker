using BattleShipStateTracker.Data.Data;
using BattleShipStateTracker.Data.Entities;
using BattleShipStateTracker.Data.Exceptions;
using BattleShipStateTracker.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipStateTracker.Repo
{
    public class PlayerRepo : IPlayerRepo
    {
        private readonly BattleShipDbContext _battleShipDbContext;
        public PlayerRepo(BattleShipDbContext battleShipDbContext)
        {
            _battleShipDbContext = battleShipDbContext;
        }

        public async Task<Player> GetPlayerById(int id)
        {
            var player = await _battleShipDbContext.Players.FindAsync(id);
            if (player == null)
                throw new NotFoundException(nameof(Player), id);
            return player;
        }

        public async Task<int> SetPlayer(string name)
        {
            var player = new Player()
            {
                Name = name
            };
            await _battleShipDbContext.Players.AddAsync(player);
            return player.Id;
        }
    }
}
