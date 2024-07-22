namespace FootballDataApi.Models;

internal abstract record ApiRootStructure
{
    public int Count { get; set; }

    public object Filters { get; set; }
}
