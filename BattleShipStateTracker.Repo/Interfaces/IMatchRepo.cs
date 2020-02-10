using BattleShipStateTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipStateTracker.Repo.Interfaces
{
    public interface IMatchRepo
    {
        Task<int> CreateMatch();
        Task<Match> GetMatchById(int id);
    }
}