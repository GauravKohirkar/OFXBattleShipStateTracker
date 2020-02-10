using BattleShipStateTracker.Data.CommandsDto;
using BattleShipStateTracker.Data.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipStateTracker.Repo.Interfaces
{
    public interface IShipRepo
    {
        Task<int> CreateShip(CreateShipDto createShip);
        Task<AttackResultDto> AttackShip(AttackDto attackDto);

    }
}
