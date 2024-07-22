using System;

namespace FootballDataApi.Models.Scorers;

public sealed record ScorerTeam : Team
{
    public string Address { get; set; }

    public string Phone { get; set; }

    public string Website { get; set; }

    public string Email { get; set; }

    public int Founded { get; set; }

    public string ClubColors { get; set; }

    public string Venue { get; set; }

    public DateTime LastUpdated { get; set; }
}


