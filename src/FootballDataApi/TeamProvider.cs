using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Services;
using FootballDataApi.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballDataApi;

internal sealed class TeamProvider : ITeamProvider
{
    private readonly HttpClient _httpClient;

    public TeamProvider(HttpClient httpClient)
        => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<IEnumerable<Team>> GetTeamByCompetition(int competitionId, params string[] filters)
    {
        string[] authorizedFilters = ["stage"];

        HttpHelpers.VerifyActionParameters(competitionId, filters, authorizedFilters);

        var urlTeamByCompetition = $"competitions/{competitionId}/teams";

        urlTeamByCompetition = HttpHelpers.AddFiltersToUrl(urlTeamByCompetition, filters);

        var teamRoot = await _httpClient.GetAsync<RootTeam>(urlTeamByCompetition);

        return teamRoot.Teams;
    }

    public Task<Team> GetTeamById(int teamId)
    {
        HttpHelpers.VerifyActionParameters(teamId, null, null);

        return _httpClient.GetAsync<Team>($"teams/{teamId}");
    }
}
