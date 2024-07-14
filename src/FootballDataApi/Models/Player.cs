using System;

namespace FootballDataApi.Models;

public sealed record Player
{
    public int? Id { get; set; }

    public string Name { get; set; }

    public string Position { get; set; }

    public int? ShirtNumber { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string CountryOfBirth { get; set; }

    public string Nationality { get; set; }

    public string Role { get; set; }
}
