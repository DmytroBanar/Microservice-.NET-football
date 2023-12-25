using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Interfaces;

namespace UnitOfWorkDemo.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;
        public IFootballTeamRepository Teams { get; }
        public IFootballLeagueRepository Leagues { get; }

        public UnitOfWork(DbContextClass dbContext, IFootballTeamRepository teamRepository, IFootballLeagueRepository leagueRepository)
        {
            _dbContext = dbContext;
            Teams = teamRepository;
            Leagues = leagueRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
    public class UnitOfWorkFactory
    {
        private readonly DbContextClass _dbContext;
        private readonly IFootballTeamRepository _teamRepository;
        private readonly IFootballLeagueRepository _leagueRepository;

        public UnitOfWorkFactory(DbContextClass dbContext, IFootballTeamRepository teamRepository, IFootballLeagueRepository leagueRepository)
        {
            _dbContext = dbContext;
            _teamRepository = teamRepository;
            _leagueRepository = leagueRepository;
        }

        public IUnitOfWork CreateTeamUnitOfWork()
        {
            return new UnitOfWork(_dbContext, _teamRepository, _leagueRepository);
        }

        public IUnitOfWork CreateLeagueUnitOfWork()
        {
            return new UnitOfWork(_dbContext, _teamRepository, _leagueRepository);
        }
    }

}
