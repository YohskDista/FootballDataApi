using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Utilities
{
    public class RootMatch : RootApi
    {
        public IEnumerable<Match> Matches { get; set; }
    }
}
