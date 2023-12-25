using Dapper;
using System.Data;
using Npgsql;
using WebApi.Contracts;
using WebApi.Dto;
using WebApi.Entities;

namespace WebApi.Repository
{
    public class FootballTeamRepository : IFootballTeamRepository
    {
        private readonly string _connectionString;

        public FootballTeamRepository(string connectionString = "Host=localhost;Port=5432;Database=Football;Username=postgres;Password=29022004bd;")
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public async Task<IEnumerable<FootballTeam>> GetTeams()
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                var query = "SELECT TeamId, TeamName, TeamCountry, TeamCountryRegion FROM FootballTeam";
                return await connection.QueryAsync<FootballTeam>(query);
            }
        }

        public async Task<FootballTeam> GetTeam(int id)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                var query = "SELECT * FROM FootballTeam WHERE TeamId = @TeamId";
                return await connection.QueryFirstOrDefaultAsync<FootballTeam>(query, new { TeamId = id });
            }
        }

        public async Task<FootballTeam> CreateTeam(FootballTeamForCreationDto team)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                var query = "INSERT INTO FootballTeam (TeamName, TeamCountry, TeamCountryRegion) " +
                            "VALUES (@TeamName, @TeamCountry, @TeamCountryRegion) RETURNING TeamId";
                return await connection.QueryFirstOrDefaultAsync<FootballTeam>(query, team);
            }
        }
        public async Task UpdateTeam(int id, FootballTeamForUpdateDto team)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                var query = "UPDATE FootballTeam SET TeamName = @TeamName, TeamCountry = @TeamCountry, " +
                            "TeamCountryRegion = @TeamCountryRegion WHERE TeamId = @TeamId";
                await connection.ExecuteAsync(query, new { TeamId = id, team.TeamName, team.TeamCountry, team.TeamCountryRegion});
            }
        }

            public async Task DeleteTeam(int id)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                var query = "DELETE FROM FootballTeam WHERE TeamId = @TeamId";
                await connection.ExecuteAsync(query, new { TeamId = id });
            }
        }

        public async Task<FootballTeam> GetTeamByPlayerId(int playerId)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                var query = "SELECT t.TeamId, t.TeamName, t.TeamCountry, t.TeamCountryRegion " +
             "FROM FootballTeam t " +
             "WHERE t.TeamId = (SELECT TeamNameId FROM Player WHERE PlayerId = @PlayerId)";
                return await connection.QueryFirstOrDefaultAsync<FootballTeam>(query, new { PlayerId = playerId });
            }
        }

        
        /*public async Task<List<FootballTeam>> GetTeamsPlayersMultipleMapping()
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                var query = "SELECT t.TeamId, t.TeamName, t.TeamCountry, t.TeamCountryRegion, t.TeamNameId" +
                            "p.PlayerId, p.PlayerName, p.PlayerSurname, p.PlayerAge, p.FootballTeam, " +
                            "p.PlayerCountry, p.PlayerPosition, p.PlayerCostInMillions, p.TeamNameId " +
                            "FROM FootballTeam t " +
                            "LEFT JOIN Players p ON t.TeamId = p.FootballTeam";

                var teamDict = new Dictionary<int, FootballTeam>();
                var teams = new List<FootballTeam>();

                using (var multi = connection.QueryMultiple(query))
                {
                    var results = multi.Read<FootballTeam, Player, FootballTeam>(
                        (team, player) =>
                        {
                            if (!teamDict.TryGetValue(team.TeamId, out var currentTeam))
                            {
                                currentTeam = team;
                                currentTeam.Players = new List<Player>();
                                teamDict.Add(currentTeam.TeamId, currentTeam);
                                teams.Add(currentTeam);
                            }
                            currentTeam.Players.Add(player);
                            return currentTeam;
                        },
                        splitOn: "PlayerId"
                    );

                    // Забезпечте унікальні команди
                    return teams.Distinct().ToList();
                }
            }
        }*/

       

    }
}
