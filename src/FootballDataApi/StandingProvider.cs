using FootballDataApi.Extensions;
using FootballDataApi.Models.Standings;
using FootballDataApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi;

internal sealed class StandingProvider : IStandingProvider
{
    private readonly IDataProvider _dataProvider;

    public StandingProvider(IDataProvider dataProvider)
        => _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));

    public Task<IReadOnlyCollection<Standing>> GetStandingAtAsync(
        string competitionId, 
        DateTime date, 
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(competitionId);

        return GetStandingsWithFiltersAsync(competitionId, [nameof(date), date.ToString("yyyy-MM-dd")], cancellationToken);
    }

    public Task<IReadOnlyCollection<Standing>> GetStandingOfCompetitionAsync(
        string competitionId,
        int? season = null, 
        int? matchDay = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(competitionId);

        var filters = new List<string>();

        if (season is not null)
        {
            filters.AddRange([nameof(season), $"{season}"]);
        }

        if (matchDay is not null)
        {
            filters.AddRange([nameof(matchDay), $"{matchDay}"]);
        }

        return GetStandingsWithFiltersAsync(competitionId, filters.ToArray(), cancellationToken);
    }

    private async Task<IReadOnlyCollection<Standing>> GetStandingsWithFiltersAsync(
        string competitionId, 
        string[] filters, 
        CancellationToken cancellationToken = default)
    {
        var url = HttpHelpers.AddFiltersToUrl(
            $"competitions/{competitionId}/standings",
            filters);

        var standingsRoot = await _dataProvider.GetAsync<StandingsRoot>(
            url,
            cancellationToken);

        return standingsRoot.Standings;
    }
}
