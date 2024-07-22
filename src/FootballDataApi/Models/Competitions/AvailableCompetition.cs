using System;

namespace FootballDataApi.Models.Competitions
{
    public sealed record AvailableCompetition : Competition
    {
        public Area Area { get; set; }

        public string Plan { get; set; }

        public Season CurrentSeason { get; set; }

        public int NumberOfAvailableSeasons { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
