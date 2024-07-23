using FootballDataApi.Extensions;
using FootballDataApi.Models.Matches;
using FootballDataApi.Models.Teams;
using FootballDataApi.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
}
