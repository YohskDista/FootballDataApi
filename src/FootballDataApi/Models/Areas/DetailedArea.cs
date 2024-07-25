namespace FootballDataApi.Models;

public record DetailedArea
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? CountryCode { get; set; }

    public string? Flag { get; set; }

    public int? ParentAreaId { get; set; }

    public string? ParentArea { get; set; }
}