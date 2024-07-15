using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Services;
using FootballDataApi.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballDataApi;

internal sealed class AreaProvider : IAreaProvider
{
    private static string BaseAddress = "http://api.football-data.org/v2/areas";
    
    private HttpClient _httpClient;

    internal AreaProvider(HttpClient httpClient)
        => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<IEnumerable<Area>> GetAllAreas()
    {
        var url = $"{BaseAddress}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        var rootArea = await _httpClient.Get<RootArea>(request);

        return rootArea.Areas;
    }

    public async Task<Area> GetAreaById(int idArea)
    {
        HttpHelpers.VerifyActionParameters(idArea, null, null);

        var url = $"{BaseAddress}/{idArea}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        return await _httpClient.Get<Area>(request);
    }
}
