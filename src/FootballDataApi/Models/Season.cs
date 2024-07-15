using System;

namespace FootballDataApi.Models;

public sealed record Season
{
    public int Id { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? CurrentMatchday { get; set; }

    public string? Winner {  get; set; }

    public string[] Stages { get; set; }
}
