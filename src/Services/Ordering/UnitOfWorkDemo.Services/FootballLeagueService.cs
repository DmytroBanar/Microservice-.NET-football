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
    public class FootballLeagueService : IFootballLeagueService
    {
        public IUnitOfWork _unitOfWork;

        public FootballLeagueService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateLeague(FootballLeagueDetails leagueDetails)
        {
            if (leagueDetails != null)
            {
                await _unitOfWork.Leagues.Add(leagueDetails);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteLeague(int LeagueId)
        {
            if (LeagueId > 0)
            {
                var leagueDetails = await _unitOfWork.Leagues.GetById(LeagueId);
                if (leagueDetails != null)
                {
                    _unitOfWork.Leagues.Delete(leagueDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<FootballLeagueDetails>> GetAllLeagues()
        {
            var leagueDetailsList = await _unitOfWork.Leagues.GetAll();
            return leagueDetailsList;
        }

        public async Task<FootballLeagueDetails> GetLeagueById(int leagueId)
        {
            if (leagueId > 0)
            {
                var leagueDetails = await _unitOfWork.Leagues.GetById(leagueId);
                if (leagueDetails != null)
                {
                    return leagueDetails;
                }
            }
            return null;
        }


        public async Task<bool> UpdateLeague(FootballLeagueDetails leagueDetails)
        {
            if (leagueDetails != null)
            {
                var league = await _unitOfWork.Leagues.GetById(leagueDetails.LeagueId);
                if (league != null)
                {
                    league.LeagueName = leagueDetails.LeagueName;
                    league.LeagueCountry = leagueDetails.LeagueCountry;
                    league.LeagueCapacity = leagueDetails.LeagueCapacity;
                    league.LeagueNumberOfPlayers = leagueDetails.LeagueNumberOfPlayers;

                    _unitOfWork.Leagues.Update(league);

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
