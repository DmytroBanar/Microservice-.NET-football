using UnitOfWorkDemo.Core.Interfaces;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Infrastructure.Repositories
{
    public class FootballLeagueRepository : GenericRepository<FootballLeagueDetails>, IFootballLeagueRepository
    {
        public FootballLeagueRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
