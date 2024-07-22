using FootballDataApi.Extensions;
using FootballDataApi.Models.Teams;
using FootballDataApi.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi;

internal sealed class TeamProvider : ITeamProvider
{
    private readonly HttpClient _httpClient;

    public TeamProvider(HttpClient httpClient)
        => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

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

        var root = await _httpClient.GetAsync<TeamsByCompetitionRoot>(urlTeamByCompetition, cancellationToken);

        return root.Teams;
    }

    public Task<FullDetailedTeam> GetTeamByIdAsync(
        int teamId,
        CancellationToken cancellationToken = default)
    {
        HttpHelpers.VerifyActionParameters(teamId, null, null);

        return _httpClient.GetAsync<FullDetailedTeam>($"teams/{teamId}", cancellationToken);
    }
}
