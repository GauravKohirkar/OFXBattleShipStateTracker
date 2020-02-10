using BattleShipStateTracker.Repo;
using BattleShipStateTracker.Repo.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleShipStateTracker.Tests
{
    [TestClass]
    public class MatchTest : TestBase
    {
        private IMatchRepo matchRepo;
        public MatchTest()
        {
            matchRepo = new MatchRepo(_battleShipDbContext);
        }
        [TestMethod]
        public void Cherck_If_Match_Is_Not_Null()
        {
            var a = matchRepo.GetMatchById(1);
            Assert.Equals(a != null, true);
        }
    }
}
