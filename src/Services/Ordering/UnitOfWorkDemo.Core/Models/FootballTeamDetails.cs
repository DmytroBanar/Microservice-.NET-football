using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UnitOfWorkDemo.Core.Models
{
    public class FootballTeamDetails
    {
        [Key]public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamCountry { get; set; }
        public int TeamPriceInMillions { get; set; }
       
        
        public int TeamLeagueId { get; set; }
        [JsonIgnore]public FootballLeagueDetails?  TeamLeague { get; set; }
    }
}
