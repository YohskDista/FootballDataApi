using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Services;
using FootballDataApi.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballDataApi;

internal sealed class AreaProvider : IAreaProvider
{    
    private HttpClient _httpClient;

    public AreaProvider(HttpClient httpClient)
        => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<IEnumerable<Area>> GetAllAreas()
    {
        var rootArea = await _httpClient.GetAsync<RootArea>("areas");

        return rootArea.Areas;
    }

    public Task<Area> GetAreaById(int idArea)
    {
        HttpHelpers.VerifyActionParameters(idArea, null, null);

        return _httpClient.GetAsync<Area>($"areas/{idArea}");
    }
}
