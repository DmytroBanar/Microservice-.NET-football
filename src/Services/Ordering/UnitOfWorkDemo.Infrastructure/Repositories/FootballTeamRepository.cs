using UnitOfWorkDemo.Core.Interfaces;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Infrastructure.Repositories
{
    public class FootballTeamRepository : GenericRepository<FootballTeamDetails>, IFootballTeamRepository
    {
        public FootballTeamRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
