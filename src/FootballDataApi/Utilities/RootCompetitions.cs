using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Utilities
{
    public class RootCompetitions
    {
        public int Count { get; set; }
        public object Filters { get; set; }
        public IEnumerable<Competition> Competitions { get; set; }
    }
}
