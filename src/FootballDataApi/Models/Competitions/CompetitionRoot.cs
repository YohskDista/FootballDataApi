using System.Collections.Generic;

namespace FootballDataApi.Models.Competitions
{
    public sealed record CompetitionRoot
    {
        public int Count { get; set; }

        public CompetitionFilter Filter { get; set; }

        public IReadOnlyCollection<AvailableCompetition> Competitions { get; set; }
    }

    public sealed record CompetitionFilter
    {
        public string Client { get; set; }
    }
}
