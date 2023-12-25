using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Services.Interfaces
{
    public interface IFootballTeamService
    {
        Task<bool> CreateTeam(FootballTeamDetails teamDetails);

        Task<IEnumerable<FootballTeamDetails>> GetAllTeams();

        Task<FootballTeamDetails> GetTeamById(int TeamId);

        Task<bool> UpdateTeam(FootballTeamDetails teamDetails);

        Task<bool> DeleteTeam(int teamId);
    }
}
