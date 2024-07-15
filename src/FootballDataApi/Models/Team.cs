﻿using System;
using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record Team
{
    public int? Id { get; set; }

    public Area Area { get; set; }

    public string Name { get; set; }

    public string ShortName { get; set; }

    public string Tla { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public string Website { get; set; }

    public string Email { get; set; }

    public int Founded { get; set; }

    public string ClubColors { get; set; }

    public object Venue { get; set; }

    public IReadOnlyCollection<Player> Squad { get; set; }

    public DateTime LastUpdated { get; set; }
}
