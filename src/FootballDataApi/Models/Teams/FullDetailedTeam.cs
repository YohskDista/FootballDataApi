﻿using System;
using System.Collections.Generic;

namespace FootballDataApi.Models.Teams;

public sealed record FullDetailedTeam : Team
{
    public Area Area { get; set; }

    public string Address { get; set; }

    public string Website { get; set; }

    public int Founded { get; set; }

    public string ClubColors { get; set; }

    public string Venue { get; set; }

    public IReadOnlyCollection<Competition> RunningCompetitions { get; set; }

    public Coach Coach { get; set; }

    public int MarketValue { get; set; }

    public IReadOnlyCollection<Squad> Squad { get; set; }

    public IReadOnlyCollection<Staff> Staff { get; set; }

    public DateTime LastUpdated { get; set; }
}


