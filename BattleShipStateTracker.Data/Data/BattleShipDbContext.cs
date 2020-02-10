using System.Threading.Tasks;
using BattleShipStateTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BattleShipStateTracker.Data.Data
{
    public class BattleShipDbContext : DbContext
    {
        public BattleShipDbContext(DbContextOptions<BattleShipDbContext> options) : base(options)
        {
        }
        public BattleShipDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

        }
        public DbSet<Match> Matches { get; set; }
        public DbSet<BattleShip> BattleShips { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<BattleShipCoordinate> BattleShipCoordinates { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
