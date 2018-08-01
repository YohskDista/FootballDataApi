using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Utilities
{
    public sealed class RootMatches
    {
        public int Count { get; set; }
        public object Filters { get; set; }
        public IEnumerable<Match> Matches { get; set; }
    }
}
