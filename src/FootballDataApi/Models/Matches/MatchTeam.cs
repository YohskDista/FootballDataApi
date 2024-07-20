using System.Collections.Generic;

namespace FootballDataApi.Models.Matches;

public sealed record MatchTeam
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? ShortName { get; set; }

    public string? Tla { get; set; }

    public string? Crest { get; set; }

    public Coach? Coach { get; set; }

    public string LeagueRank { get; set; }

    public string Formation { get; set; }

    public IReadOnlyCollection<Person>? Lineup { get; set; }

    public IReadOnlyCollection<Person>? Bench { get; set; }

    public Statistics? Statistics { get; set; }
}

public sealed record GoalTeam
{
    public int Id { get; set; }

    public string Team { get; set; }
}
