using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Core.Models
{
    public class FootballLeagueDetails
    {
        [Key]public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        public string LeagueCountry { get; set; }
        public int LeagueCapacity { get; set; }
        public int LeagueNumberOfPlayers { get; set; }
        [JsonIgnore]public List<FootballTeamDetails> Teams { get; set; } = new();
    }
}
