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
    private static string BaseAddress = "http://api.football-data.org/v2/competitions";

    private readonly HttpClient _httpClient;

    internal CompetitionProvider(HttpClient httpClient) 
        => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<IEnumerable<Competition>> GetAvailableCompetition()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, BaseAddress);
        var competitionRoot = await _httpClient.Get<RootCompetition>(request);

        return competitionRoot.Competitions;
    }

    public async Task<IEnumerable<Competition>> GetAvailableCompetitionByArea(int areaId)
    {
        HttpHelpers.VerifyActionParameters(areaId, null, null);

        var urlAreas = $"{BaseAddress}/?areas={ areaId }";

        var request = new HttpRequestMessage(HttpMethod.Get, urlAreas);
        var competitionRoot = await _httpClient.Get<RootCompetition>(request);

        return competitionRoot.Competitions;
    }

    public async Task<Competition> GetCompetition(int idCompetition)
    {
        HttpHelpers.VerifyActionParameters(idCompetition, null, null);

        var url = $"{BaseAddress}/{idCompetition}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        return await _httpClient.Get<Competition>(request);
    }
}
