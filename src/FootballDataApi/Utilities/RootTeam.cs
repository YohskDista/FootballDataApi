using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Utilities
{
    public class RootTeam
    {
        public int Count { get; set; }
        public object Filters { get; set; }
        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}
