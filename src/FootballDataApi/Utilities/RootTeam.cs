using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Utilities
{
    public class RootTeam : RootApi
    {
        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}
