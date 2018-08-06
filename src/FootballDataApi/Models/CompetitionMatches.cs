using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Models
{
    public class CompetitionMatches
    {
        public int Count { get; set; }
        public object Filters { get; set; }
        public Season Season { get; set; }
        public IEnumerable<Match> Matches { get; set; }
    }
}
