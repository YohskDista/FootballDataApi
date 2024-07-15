using System;

namespace FootballDataApi.Models;

public sealed record Coach
{
    public int? Id { get; set; }

    public string Name { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Nationality { get; set; }

    public Contract Contract { get; set; }
}

public sealed record Contract
{
    public string Start { get; set; }

    public string Until { get; set; }
}