using System.Collections.Generic;

namespace FootballDataApi.Models.Competitions;

public sealed record Season
{
    public int Id { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public int? CurrentMatchday { get; set; }
    public Winner Winner { get; set; }
    public IReadOnlyList<string> stages { get; set; }
}

