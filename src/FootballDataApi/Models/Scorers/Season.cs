using System;
using System.Collections.Generic;

namespace FootballDataApi.Models.Scorers;

public class Season
{
    public int Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int CurrentMatchday { get; set; }

    public Winner Winner { get; set; }

    public IReadOnlyCollection<string> Stages { get; set; }
}


