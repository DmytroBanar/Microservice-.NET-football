

namespace UnitOfWorkDemo.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFootballTeamRepository Teams { get; }
        IFootballLeagueRepository Leagues { get; }

        int Save();
    }
}
