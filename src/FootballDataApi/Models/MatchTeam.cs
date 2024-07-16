using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record MatchTeam
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? ShortName { get; set; }

    public string? Tla { get; set; }

    public string? Crest { get; set; }

    public Coach? Coach { get; set; }

    public IReadOnlyCollection<Person>? Lineup { get; set; }

    public IReadOnlyCollection<Person>? Bench { get; set; }

    public Statistics? Statistics { get; set; }
}
