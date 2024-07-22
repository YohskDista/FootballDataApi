using System;

namespace FootballDataApi.Models.Scorers;

public sealed record Player : Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string DateOfBirth { get; set; }

    public string CountryOfBirth { get; set; }

    public string Nationality { get; set; }

    public string Position { get; set; }

    public object ShirtNumber { get; set; }

    public DateTime LastUpdated { get; set; }
}


