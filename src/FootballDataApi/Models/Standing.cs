using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Models
{
    public class Standing
    {
        public string Stage { get; set; }
        public string Type { get; set; }
        public object Group { get; set; }
        public IEnumerable<Ranking> Table { get; set; }
    }
}
