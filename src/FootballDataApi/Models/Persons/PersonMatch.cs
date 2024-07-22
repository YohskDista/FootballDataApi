using System;

namespace FootballDataApi.Models.Persons;

public sealed record PersonMatch : Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string DateOfBirth { get; set; }

    public string Nationality { get; set; }

    public string Position { get; set; }

    public int? ShirtNumber { get; set; }

    public DateTime LastUpdated { get; set; }
}


