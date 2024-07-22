namespace FootballDataApi.Models;

public record Team
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string ShortName { get; set; }

    public string Tla { get; set; }

    public string Crest { get; set; }
}


