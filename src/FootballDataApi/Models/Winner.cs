using System;

namespace FootballDataApi.Models;

public class Winner
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string ShortName { get; set; }

    public string Tla { get; set; }

    public string Crest { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public string Website { get; set; }

    public string Email { get; set; }

    public int Founded { get; set; }

    public string ClubColors { get; set; }

    public string Venue { get; set; }

    public DateTime LastUpdated { get; set; }
}


