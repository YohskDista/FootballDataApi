using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Models
{
    public class SeasonStanding
    {
        public Season Season { get; set; }
        public IEnumerable<Standing> Standings { get; set; }
    }

    public class Standing
    {
        public string Stage { get; set; }
        public string Type { get; set; }
        public object Group { get; set; }
        public IEnumerable<Ranking> Table { get; set; }
    }


    public class Ranking
    {
        public int Position { get; set; }
        public Club Team { get; set; }
        public int PlayedGames { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
        public int Points { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
    }
}
