﻿using System;

namespace FootballDataApi.Models.Persons;

public sealed record Person
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string DateOfBirth { get; set; }

    public string Nationality { get; set; }

    public string Position { get; set; }

    public int ShirtNumber { get; set; }

    public DateTime LastUpdated { get; set; }

    public CurrentTeam CurrentTeam { get; set; }
}


