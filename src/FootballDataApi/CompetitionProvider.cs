using FootballDataApi.Extensions;
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

    public async Task<IReadOnlyCollection<AvailableCompetition>> GetAvailableCompetition()
    {
        var competitionRoot = await _httpClient.GetAsync<CompetitionRoot>("competitions");

        return competitionRoot.Competitions;
    }

    public async Task<IReadOnlyCollection<AvailableCompetition>> GetAvailableCompetitionByArea(int areaId)
    {
        HttpHelpers.VerifyActionParameters(areaId, null, null);

        var competitionRoot = await _httpClient.GetAsync<CompetitionRoot>($"competitions?areas={areaId}");

        return competitionRoot.Competitions;
    }

    public Task<DetailedCompetition> GetCompetition(string competitionId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(competitionId);

        return _httpClient.GetAsync<DetailedCompetition>($"competitions/{competitionId}");
    }
}
