using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Models
{
    public class CompetitionRoot
    {
        public int Count { get; set; }
        public object Filters { get; set; }
        public IEnumerable<Competition> Competitions { get; set; }
    }

    public class Competition
    {
        public int Id { get; set; }
        public Area Area { get; set; }
        public string Name { get; set; }
        public object Code { get; set; }
        public string Plan { get; set; }
        public Season CurrentSeason { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
        public int NumberOfAvailableSeasons { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Season
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CurrentMatchday { get; set; }
        public string[] AvailableStages { get; set; }
    }
}
