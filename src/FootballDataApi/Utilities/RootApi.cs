namespace FootballDataApi.Utilities;

public abstract record RootApi
{
    public int Count { get; set; }

    public object Filters { get; set; }
}
