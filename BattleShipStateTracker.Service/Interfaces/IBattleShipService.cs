using BattleShipStateTracker.Data.CommandsDto;
using BattleShipStateTracker.Data.Entities;
using BattleShipStateTracker.Data.ResponseDto;
using System.Threading.Tasks;

namespace BattleShipStateTracker.Service.Interfaces
{
    public interface IBattleShipService
    {
        Task<int> CreateMatch();
        Task<Match> GetMatchById(int id);
        Task<Board> SetBoard(SetBoardDto setBoard);
        Task<int> CreateShip(CreateShipDto createShip);
        Task<AttackResultDto> AttackShip(AttackDto attackDto);
        Task<int> CreatePlayer(string name);
    }
}
