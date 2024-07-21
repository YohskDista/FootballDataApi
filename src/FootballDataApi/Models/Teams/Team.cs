using System;
using System.Collections.Generic;

namespace FootballDataApi.Models.Teams;

public sealed record Team
{
    public Area Area { get; set; }

    public int Id { get; set; }

    public string Name { get; set; }

    public string ShortName { get; set; }

    public string Tla { get; set; }

    public string Crest { get; set; }

    public string Address { get; set; }

    public string Website { get; set; }

    public int Founded { get; set; }

    public string ClubColors { get; set; }

    public string Venue { get; set; }

    public IReadOnlyCollection<RunningCompetition> RunningCompetitions { get; set; }

    public Coach Coach { get; set; }

    public int MarketValue { get; set; }

    public IReadOnlyCollection<Squad> Squad { get; set; }

    public IReadOnlyCollection<Staff> Staff { get; set; }

    public DateTime LastUpdated { get; set; }
}


