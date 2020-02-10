using BattleShipStateTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipStateTracker.Repo.Interfaces
{
    public interface IBoardRepo
    {
        Task<Board> SetBoard(Match match, int SizeX, int SizeY);
    }
}
