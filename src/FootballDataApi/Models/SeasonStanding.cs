using System.Collections.Generic;

namespace FootballDataApi.Models
{
    public class SeasonStanding
    {
        public Season Season { get; set; }
        public IEnumerable<Standing> Standings { get; set; }
    }
}
