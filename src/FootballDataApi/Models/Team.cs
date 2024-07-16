using System;
using System.Collections.Generic;

namespace FootballDataApi.Models;

public record Club
{
    public Area? Area { get; set; }

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ShortName { get; set; }

    public string? Tla { get; set; }

    public string? Crest { get; set; }

    public string? Address { get; set; }

    public string? Website { get; set; }

    public int? Founded { get; set; }

    public string? ClubColors { get; set; }

    public string? Venue { get; set; }
}

public record Team : Club
{
    public long? MarketValue { get; set; }

    public Coach? Coach { get; set; }

    public IReadOnlyCollection<Competition>? RunningCompetitions { get; set; }

    public IReadOnlyCollection<Person>? Squad { get; set; }

    public IReadOnlyCollection<Person>? Staff { get; set; }

    public DateTime? LastUpdated { get; set; }
}

public sealed record PlayerTeam : Club
{
    public Contract? Contract { get; set; }
}
