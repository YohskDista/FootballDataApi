using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record MatchTeam
{
    public int? Id { get; set; }

    public string Name { get; set; }

    public Coach Coach { get; set; }

    public Player Captain { get; set; }

    public IReadOnlyCollection<Player> Lineup { get; set; }

    public IReadOnlyCollection<Player> Bench { get; set; }
}
