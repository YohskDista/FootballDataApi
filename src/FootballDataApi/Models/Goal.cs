using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record Goal
{
    public int? Minute { get; set; }
    public Player Scorer { get; set; }
    public IEnumerable<Player> Assist { get; set; }
}
