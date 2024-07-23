using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Models.Matches;
using FootballDataApi.Models.Teams;
using FootballDataApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FootballDataApi;

internal sealed class TeamProvider : ITeamProvider
{
    private readonly IDataProvider _dataProvider;

    public TeamProvider(IDataProvider dataProvider)
        => _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));

    public async Task<IReadOnlyCollection<FullDetailedTeam>> GetTeamsByCompetitionAsync(
        string competitionId,
        CancellationToken cancellationToken = default,
        params string[] filters)
    {
        string[] authorizedFilters = ["stage"];

        //HttpHelpers.VerifyActionParameters(competitionId, filters, authorizedFilters);
        ArgumentException.ThrowIfNullOrWhiteSpace(competitionId);

        var urlTeamByCompetition = $"competitions/{competitionId}/teams";

        urlTeamByCompetition = HttpHelpers.AddFiltersToUrl(urlTeamByCompetition, filters);

        var root = await _dataProvider.GetAsync<TeamsByCompetitionRoot>(urlTeamByCompetition, cancellationToken);

        return root.Teams;
    }

    public Task<FullDetailedTeam> GetTeamByIdAsync(
        int teamId,
        CancellationToken cancellationToken = default)
    {
        HttpHelpers.VerifyActionParameters(teamId, null, null);

        return _dataProvider.GetAsync<FullDetailedTeam>($"teams/{teamId}", cancellationToken);
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

    public Task<IReadOnlyCollection<Match>> GetMatchesForTeamAsync(
        int teamId, 
        int season, 
        Status? status = null, 
        Venue? venue = null, 
        int limit = 500, 
        CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(teamId, 0);
        ArgumentOutOfRangeException.ThrowIfLessThan(season, 0);
        
        if (limit is < 1 or > 500)
        {
            throw new ArgumentOutOfRangeException(
                nameof(limit), limit, "The value must be between [1, 500]");
        }

        var filters = new string[]
        {
            nameof(season),
            $"{season}",
            nameof(limit),
            $"{limit}"
        };

        return GetMatchesWithFilters(teamId, filters, status, venue, cancellationToken);
    }

    public Task<IReadOnlyCollection<Match>> GetMatchesForTeamBetweenAsync(
        int teamId, 
        DateTime dateFrom, 
        DateTime dateTo, 
        Status? status = null, 
        Venue? venue = null, 
        int limit = 500, 
        CancellationToken cancellationToken = default)
    {
        if (dateTo < dateFrom)
        {
            throw new ArgumentException("dateTo cannot be before dateFrom.", nameof(dateTo));
        }

        if (limit is < 1 or > 500)
        {
            throw new ArgumentOutOfRangeException(
                nameof(limit), limit, "The value must be between [1, 500]");
        }

        var filters = new string[]
        {
            nameof(dateFrom),
            dateFrom.ToString("yyyy-MM-dd"),
            nameof(dateTo),
            dateTo.ToString("yyyy-MM-dd"),
            nameof(limit),
            $"{limit}"
        };

        return GetMatchesWithFilters(teamId, filters, status, venue, cancellationToken);
    }

    private async Task<IReadOnlyCollection<Match>> GetMatchesWithFilters(
        int teamId,
        string[] existingFilters,
        Status? status = null,
        Venue? venue = null,
        CancellationToken cancellationToken = default)
    {
        var filters = new List<string>();

        if (status is not null)
        {
            filters.AddRange([nameof(status), $"{status}"]);
        }

        if (venue is not null)
        {
            filters.AddRange([nameof(venue), $"{venue}"]);
        }

        var url = HttpHelpers.AddFiltersToUrl(
            $"teams/{teamId}/matches", filters.Concat(existingFilters).ToArray());

        var rootMatches = await _dataProvider.GetAsync<MatchRoot>(url, cancellationToken);

        return rootMatches.Matches;
    }
}
