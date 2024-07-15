using FootballDataApi.Models;
using System.Collections.Generic;

namespace FootballDataApi.Utilities;

internal sealed record RootArea : RootApi
{
    public IReadOnlyCollection<Area> Areas { get; set; }
}
