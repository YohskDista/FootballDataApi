using System.Collections.Generic;

namespace FootballDataApi.Models
{
    public class Goal
    {
        public int? Minute { get; set; }
        public Player Scorer { get; set; }
        public IEnumerable<Player> Assist { get; set; }
    }

}
