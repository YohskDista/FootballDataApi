using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Models.Competitions;
using FootballDataApi.Services;
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

    public async Task<IReadOnlyCollection<Competition>> GetAvailableCompetition()
    {
        var competitionRoot = await _httpClient
            .GetAsync<IReadOnlyCollection<DetailedCompetition>>("competitions");

        return competitionRoot;
    }

    public async Task<IReadOnlyCollection<Competition>> GetAvailableCompetitionByArea(int areaId)
    {
        HttpHelpers.VerifyActionParameters(areaId, null, null);

        var competitionRoot = await _httpClient
            .GetAsync<IReadOnlyCollection<DetailedCompetition>>($"competitions?areas={areaId}");

        return competitionRoot;
    }

    public Task<DetailedCompetition> GetCompetition(string competitionId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(competitionId);

        return _httpClient.GetAsync<DetailedCompetition>($"competitions/{competitionId}");
    }
}
