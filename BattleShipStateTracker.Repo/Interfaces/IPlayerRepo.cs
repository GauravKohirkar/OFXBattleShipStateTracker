using BattleShipStateTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipStateTracker.Repo.Interfaces
{
    public interface IPlayerRepo
    {
        Task<int> SetPlayer(string name);
        Task<Player> GetPlayerById(int id);

    }
}
