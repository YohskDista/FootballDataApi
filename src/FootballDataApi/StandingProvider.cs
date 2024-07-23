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

        return GetStandingsAsync(competitionId, ["date", date.ToString("yyyy-MM-dd")], cancellationToken);
    }

    public Task<IReadOnlyCollection<Standing>> GetStandingOfCompetitionAsync(
        string competitionId,
        int? seasonYear = null, 
        int? matchDay = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(competitionId);

        var filters = new List<string>();

        if (seasonYear is not null)
        {
            filters.AddRange(["season", $"{seasonYear}"]);
        }

        if (matchDay is not null)
        {
            filters.AddRange(["matchday", $"{matchDay}"]);
        }

        return GetStandingsAsync(competitionId, filters.ToArray(), cancellationToken);
    }

    private async Task<IReadOnlyCollection<Standing>> GetStandingsAsync(
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
