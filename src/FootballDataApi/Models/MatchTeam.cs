using System.Collections.Generic;

namespace FootballDataApi.Models
{
    public class MatchTeam
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public Coach Coach { get; set; }
        public Player Captain { get; set; }
        public IEnumerable<Player> Lineup { get; set; }
        public IEnumerable<Player> Bench { get; set; }
    }

}
