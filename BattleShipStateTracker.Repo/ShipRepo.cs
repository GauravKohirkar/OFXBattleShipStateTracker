using BattleShipStateTracker.Data.CommandsDto;
using BattleShipStateTracker.Data.Data;
using BattleShipStateTracker.Data.Entities;
using BattleShipStateTracker.Data.Enums;
using BattleShipStateTracker.Data.Exceptions;
using BattleShipStateTracker.Data.ResponseDto;
using BattleShipStateTracker.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipStateTracker.Repo
{
    public class ShipRepo : IShipRepo
    {
        private readonly BattleShipDbContext _battleShipDbContext;
        public ShipRepo(BattleShipDbContext battleShipDbContext)
        {
            _battleShipDbContext = battleShipDbContext;
        }

        public async Task<int> CreateShip(CreateShipDto createShip)
        {
            var boardEntity = await _battleShipDbContext.Boards.FindAsync(createShip.BoardId);
            if (boardEntity == null)
                throw new NotFoundException(nameof(Board), createShip.BoardId);
            List<int> lstX = new List<int>();
            List<int> lstY = new List<int>();
            if (createShip.Orientation == BattleShipOrientation.Horizontal)
            {
                for (int t = 0; t < createShip.ShipLength; t++)
                {
                    lstY.Add(createShip.StartY + t);
                }
            }
            else
            {
                for (int t = 0; t < createShip.ShipLength; t++)
                {
                    lstX.Add(createShip.StartX + t);
                }
            }
            var overridenParts = _battleShipDbContext.BattleShips.Include(x => x.BattleShipCoordinates).
                Where(x => x.Board.BoardId == boardEntity.BoardId).SelectMany(x => x.BattleShipCoordinates, (p, q) => new
                {
                    q.X,
                    q.Y
                }).Where(part => lstX.Contains(part.X) && lstY.Contains(part.Y))?.ToList();
            if (overridenParts.Count > 0)
                throw new BattleShipOverrideException();
            var shipEntity = new BattleShip()
            {
                Board = boardEntity
            };
            await _battleShipDbContext.BattleShips.AddAsync(shipEntity);

            if (createShip.Orientation == BattleShipOrientation.Horizontal)
            {
                foreach (var item in lstX)
                {
                    await _battleShipDbContext.BattleShipCoordinates.AddAsync(new BattleShipCoordinate()
                    {
                        BattleShip = shipEntity,
                        X = item,
                        Y = createShip.StartY
                    });
                }
            }
            else
            {
                foreach (var item in lstY)
                {
                    await _battleShipDbContext.BattleShipCoordinates.AddAsync(new BattleShipCoordinate()
                    {
                        BattleShip = shipEntity,
                        X = createShip.StartX,
                        Y = item
                    });
                }
            }
            await _battleShipDbContext.SaveChangesAsync();
            return shipEntity.BattleShipId;
        }

        public async Task<AttackResultDto> AttackShip(AttackDto attackDto)
        {
            var player = await _battleShipDbContext.Players.FindAsync(attackDto.PlayerId);
            if (player == null)
            {
                throw new NotFoundException(nameof(Player), attackDto.PlayerId);
            }

            var board = await _battleShipDbContext.Boards.FindAsync(attackDto.BoardId);
            if (board == null)
            {
                throw new NotFoundException(nameof(Board), attackDto.BoardId);
            }

            var coordinate = await _battleShipDbContext.BattleShipCoordinates.Where(x => x.BattleShip.Board == board)
                       .Where(x => x.X == attackDto.X && x.Y == attackDto.Y).FirstOrDefaultAsync();

            // When miss happens
            if (coordinate == null)
                return new AttackResultDto() { X = attackDto.X, Y = attackDto.Y, IsHit = false };

            // When hit happens
            if (!coordinate.IsHit)
            {
                coordinate.IsHit = true;
                await _battleShipDbContext.SaveChangesAsync();
            }

            return new AttackResultDto()
            {
                X = coordinate.X,
                Y = coordinate.Y,
                IsHit = coordinate.IsHit
            };
        }
    }
}
