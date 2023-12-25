using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Interfaces;
using UnitOfWorkDemo.Core.Models;
using UnitOfWorkDemo.Services.Interfaces;

namespace UnitOfWorkDemo.Services
{
    public class FootballTeamService : IFootballTeamService
    {
        public IUnitOfWork _unitOfWork;

        public FootballTeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateTeam(FootballTeamDetails teamDetails)
        {
            if (teamDetails != null)
            {
                await _unitOfWork.Teams.Add(teamDetails);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteTeam(int TeamId)
        {
            if (TeamId > 0)
            {
                var teamDetails = await _unitOfWork.Teams.GetById(TeamId);
                if (teamDetails != null)
                {
                    _unitOfWork.Teams.Delete(teamDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<FootballTeamDetails>> GetAllTeams()
        {
            var teamDetailsList = await _unitOfWork.Teams.GetAll();
            return teamDetailsList;
        }

        public async Task<FootballTeamDetails> GetTeamById(int teamId)
        {
            if (teamId > 0)
            {
                var teamDetails = await _unitOfWork.Teams.GetById(teamId);
                if (teamDetails != null)
                {
                    return teamDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateTeam(FootballTeamDetails teamDetails)
        {
            if (teamDetails != null)
            {
                var team = await _unitOfWork.Teams.GetById(teamDetails.TeamId);
                if(team != null)
                {
                    team.TeamName= teamDetails.TeamName;
                    team.TeamCountry= teamDetails.TeamCountry;
                    team.TeamPriceInMillions = teamDetails.TeamPriceInMillions;
                    team.TeamLeagueId = teamDetails.TeamLeagueId;

                    _unitOfWork.Teams.Update(team);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
