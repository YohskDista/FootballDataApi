﻿using System;
using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record Match
{
    public int? Id { get; set; }

    public Competition Competition { get; set; }

    public Season Season { get; set; }

    public DateTime UtcDate { get; set; }

    public string Status { get; set; }

    public object Minute { get; set; }

    public int? Attendance { get; set; }

    public int? Matchday { get; set; }

    public string Stage { get; set; }

    public string Group { get; set; }

    public DateTime LastUpdated { get; set; }

    public MatchTeam HomeTeam { get; set; }

    public MatchTeam AwayTeam { get; set; }

    public Score Score { get; set; }

    public IReadOnlyCollection<Goal> Goals { get; set; }

    public IReadOnlyCollection<Booking> Bookings { get; set; }

    public IReadOnlyCollection  <Substitution> Substitutions { get; set; }

    public IReadOnlyCollection<Referee> Referees { get; set; }
}
