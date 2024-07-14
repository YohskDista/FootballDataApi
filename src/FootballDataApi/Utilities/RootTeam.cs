﻿using FootballDataApi.Models;
using System.Collections.Generic;

namespace FootballDataApi.Utilities;

public sealed record RootTeam : RootApi
{
    public Competition Competition { get; set; }

    public Season Season { get; set; }

    public IEnumerable<Team> Teams { get; set; }
}
