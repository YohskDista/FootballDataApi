using FootballDataApi.Models;
using System.Collections.Generic;

namespace FootballDataApi.Utilities;

public sealed record RootArea : RootApi
{
    public IEnumerable<Area> Areas { get; set; }
}
