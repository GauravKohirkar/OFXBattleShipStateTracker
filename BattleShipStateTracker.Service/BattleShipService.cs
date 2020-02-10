using BattleShipStateTracker.Data.CommandsDto;
using BattleShipStateTracker.Data.Entities;
using BattleShipStateTracker.Data.Exceptions;
using BattleShipStateTracker.Data.ResponseDto;
using BattleShipStateTracker.Repo.Interfaces;
using BattleShipStateTracker.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace BattleShipStateTracker.Service
{
    public class BattleShipService : IBattleShipService
    {
        private readonly IBoardRepo _boardRepo;
        private readonly IMatchRepo _matchRepo;
        private readonly IShipRepo _shipRepo;
        private readonly IPlayerRepo _playerRepo;

        public BattleShipService(IBoardRepo boardRepo, IMatchRepo matchRepo, IShipRepo shipRepo, IPlayerRepo playerRepo)
        {
            _boardRepo = boardRepo;
            _matchRepo = matchRepo;
            _shipRepo = shipRepo;
            _playerRepo = playerRepo;
        }

        public async Task<int> CreatePlayer(string name)
        {
            return await _playerRepo.SetPlayer(name);
        }

        public async Task<int> CreateMatch()
        {
            return await _matchRepo.CreateMatch();
        }

        public async Task<Match> GetMatchById(int id)
        {
            return await _matchRepo.GetMatchById(id);
        }

        public async Task<Board> SetBoard(SetBoardDto setBoard)
        {
            var match = await _matchRepo.GetMatchById(setBoard.MatchId);
            if (match == null)
                throw new NotFoundException(nameof(Match), setBoard.MatchId);
            var board = await _boardRepo.SetBoard(match, setBoard.SizeX, setBoard.SizeY);
            return board;
        }
        public async Task<int> CreateShip(CreateShipDto createShip)
        {
            return await _shipRepo.CreateShip(createShip);
        }

        public async Task<AttackResultDto> AttackShip(AttackDto attackDto)
        {
            return await _shipRepo.AttackShip(attackDto);
        }
    }
}
