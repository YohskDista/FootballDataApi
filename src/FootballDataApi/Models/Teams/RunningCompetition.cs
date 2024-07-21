﻿namespace FootballDataApi.Models.Teams;

public sealed record RunningCompetition
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public string Type { get; set; }

    public string Emblem { get; set; }
}


