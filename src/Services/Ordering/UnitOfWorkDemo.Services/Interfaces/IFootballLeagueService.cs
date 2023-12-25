using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Services.Interfaces
{
    public interface IFootballLeagueService
    {
        Task<bool> CreateLeague(FootballLeagueDetails leagueDetails);

        Task<IEnumerable<FootballLeagueDetails>> GetAllLeagues();

        Task<FootballLeagueDetails> GetLeagueById(int leagueId);

        Task<bool> UpdateLeague(FootballLeagueDetails leagueDetails);

        Task<bool> DeleteLeague(int leagueId);
    }
}
