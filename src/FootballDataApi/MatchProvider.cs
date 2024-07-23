using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Models.Matches;
using FootballDataApi.Services;

namespace FootballDataApi;

internal sealed class MatchProvider : IMatchProvider
{
    private readonly IDataProvider _dataProvider;

    public MatchProvider(IDataProvider dataProvider)
        => _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));

    public async Task<IReadOnlyCollection<Match>> GetAllMatchesOfCompetitionAsync(
        string competitionId, 
        int? season = null, 
        int? matchDay = null,
        Status? status = null,
        DateTime? dateFrom = null, 
        DateTime? dateTo = null, 
        Stage? stage = null, 
        Group? group = null, 
        CancellationToken cancellationToken = default)
    {
        if ((season is not null || matchDay is not null) 
         && (dateFrom is not null || dateTo is not null))
        {
            throw new InvalidOperationException(
                "You cannot set season or match day if you specify the dateFrom or dateTo parameter(s).");
        }

        var filters = new List<string>();

        if (season is not null)
        {
            filters.AddRange([nameof(season), $"{season}"]);
        }

        if (matchDay is not null)
        {
            filters.AddRange([nameof(matchDay), $"{matchDay}"]);
        }

        if (dateFrom is not null)
        {
            filters.AddRange([nameof(dateFrom), dateFrom?.ToString("yyyy-MM-dd")]);
        }

        if (dateTo is not null)
        {
            filters.AddRange([nameof(dateTo), dateTo?.ToString("yyyy-MM-dd")]);
        }

        if (stage is not null)
        {
            filters.AddRange([nameof(stage), $"{stage}"]);
        }

        if (group is not null)
        {
            filters.AddRange([nameof(group), $"{group}"]);
        }

        var url = HttpHelpers.AddFiltersToUrl($"competitions/{competitionId}/matches", filters.ToArray());

        var rootMatches = await _dataProvider.GetAsync<MatchRoot>(url, cancellationToken);

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