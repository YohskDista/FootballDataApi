using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FootballDataApi.Extensions;
using FootballDataApi.Models.Competitions;
using FootballDataApi.Models.Matches;
using FootballDataApi.Services;

namespace FootballDataApi;

internal sealed class MatchProvider : IMatchProvider
{
    private readonly IDataProvider _dataProvider;

    public MatchProvider(IDataProvider dataProvider)
        => _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));

    public async Task<IReadOnlyCollection<Match>> GetAllMatchesAsync(
        CancellationToken cancellationToken = default, 
        params string[] filters)
    {
        var authorizedFilters = new string[] { "ids", "date", "dateFrom", "dateTo", "status" };

        HttpHelpers.VerifyFilters(filters, authorizedFilters);

        var urlMatches = "matches";

        if (filters.Length > 0)
        {
            urlMatches = HttpHelpers.AddFiltersToUrl(urlMatches, filters);
        }

        var rootMatches = await _dataProvider.GetAsync<MatchRoot>(urlMatches, cancellationToken);

        return rootMatches.Matches;
    }

    public async Task<IReadOnlyCollection<Match>> GetAllMatchOfCompetitionAsync(
        int competitionId, 
        CancellationToken cancellationToken = default, 
        params string[] filters)
    {
        var authorizedFilters = new string[] { "dateFrom", "dateTo", "stage", "status", "matchday", "group" };

        HttpHelpers.VerifyActionParameters(competitionId, filters, authorizedFilters);

        var urlMatches = $"competitions/{competitionId}/matches";

        if (filters.Length > 0)
        {
            urlMatches = HttpHelpers.AddFiltersToUrl(urlMatches, filters);
        }

        var rootMatches = await _dataProvider.GetAsync<CompetitionMatchesRoot>(urlMatches, cancellationToken);

        return rootMatches.Matches;
    }

    public async Task<IReadOnlyCollection<Match>> GetAllMatchOfTeamAsync(
        int teamId, 
        CancellationToken cancellationToken = default, 
        params string[] filters)
    {
        var authorizedFilters = new string[] { "venue", "dateFrom", "dateTo", "status" };

        HttpHelpers.VerifyActionParameters(teamId, filters, authorizedFilters);

        var urlMatches = $"teams/{teamId}/matches";

        if (filters.Length > 0)
        {
            urlMatches = HttpHelpers.AddFiltersToUrl(urlMatches, filters);
        }

        var rootMatches = await _dataProvider.GetAsync<MatchRoot>(urlMatches, cancellationToken);

        return rootMatches.Matches;
    }

    public Task<Match> GetMatchByIdAsync(
        int matchId, 
        CancellationToken cancellationToken = default)
    {
        HttpHelpers.VerifyActionParameters(matchId, null, null);

        return _dataProvider.GetAsync<Match>($"matches/{matchId}", cancellationToken);
    }
}