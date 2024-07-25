﻿using System;
using System.Collections.Generic;

namespace FootballDataApi.Models.Matches;

public sealed record Match
{
    public int Id { get; set; }

    public Area? Area { get; set; }

    public Competition? Competition { get; set; }

    public Season? Season { get; set; }

    public DateTime UtcDate { get; set; }

    public Status Status { get; set; }

    public int Minute { get; set; }

    public int InjuryTime { get; set; }

    public int Attendance { get; set; }

    public string Venue { get; set; }

    public int Matchday { get; set; }

    public Stage Stage { get; set; }

    public Group? Group { get; set; }

    public DateTime LastUpdated { get; set; }

    public Team HomeTeam { get; set; }

    public Team AwayTeam { get; set; }

    public Score Score { get; set; }

    public IReadOnlyCollection<Goal> Goals { get; set; }

    public IReadOnlyCollection<Penalty> Penalties { get; set; }

    public IReadOnlyCollection<Booking> Bookings { get; set; }

    public IReadOnlyCollection<Substitution> Substitutions { get; set; }

    public Odds Odds { get; set; }

    public IReadOnlyCollection<Referee> Referees { get; set; }
}