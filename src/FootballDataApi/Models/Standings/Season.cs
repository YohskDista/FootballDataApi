using System.Collections.Generic;

namespace FootballDataApi.Models.Standings;

public sealed record Season
{
    public int Id { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public int CurrentMatchday { get; set; }
    public object Winner { get; set; }
    public IReadOnlyCollection<string> Stages { get; set; }
}


