using FootballDataApi.Extensions;
using FootballDataApi.Models.Teams;
using FootballDataApi.Services;
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

    public async Task<IReadOnlyCollection<FullDetailedTeam>> GetTeamByCompetition(int competitionId, params string[] filters)
    {
        string[] authorizedFilters = ["stage"];

        HttpHelpers.VerifyActionParameters(competitionId, filters, authorizedFilters);

        var urlTeamByCompetition = $"competitions/{competitionId}/teams";

        urlTeamByCompetition = HttpHelpers.AddFiltersToUrl(urlTeamByCompetition, filters);

        return await _httpClient.GetAsync<IReadOnlyCollection<FullDetailedTeam>>(urlTeamByCompetition);
    }

    public Task<FullDetailedTeam> GetTeamById(int teamId)
    {
        HttpHelpers.VerifyActionParameters(teamId, null, null);

        return _httpClient.GetAsync<FullDetailedTeam>($"teams/{teamId}");
    }
}
