using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Services;
using FootballDataApi.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballDataApi;

internal sealed class CompetitionProvider : ICompetitionProvider
{
    private readonly HttpClient _httpClient;

    public CompetitionProvider(HttpClient httpClient) 
        => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<IEnumerable<Competition>> GetAvailableCompetition()
    {
        var competitionRoot = await _httpClient.GetAsync<RootCompetition>("competitions");

        return competitionRoot.Competitions;
    }

    public async Task<IEnumerable<Competition>> GetAvailableCompetitionByArea(int areaId)
    {
        HttpHelpers.VerifyActionParameters(areaId, null, null);

        var competitionRoot = await _httpClient.GetAsync<RootCompetition>($"competitions?areas={areaId}");

        return competitionRoot.Competitions;
    }

    public Task<Competition> GetCompetition(int competitionId)
    {
        HttpHelpers.VerifyActionParameters(competitionId, null, null);

        return _httpClient.GetAsync<Competition>($"competitions/{competitionId}");
    }
}
