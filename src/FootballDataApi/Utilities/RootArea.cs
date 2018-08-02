using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Utilities
{
    public class RootArea : RootApi
    {
        public IEnumerable<Area> Areas { get; set; }
    }
}
