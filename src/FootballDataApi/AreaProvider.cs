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
    private readonly HttpClient _httpClient;

    public AreaProvider(HttpClient httpClient)
        => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<IReadOnlyCollection<DetailedArea>> GetAllAreas()
    {
        var rootArea = await _httpClient.GetAsync<RootArea>("areas");

        return rootArea.Areas;
    }

    public Task<DetailedArea> GetAreaById(int areaId)
    {
        HttpHelpers.VerifyActionParameters(areaId, null, null);

        return _httpClient.GetAsync<DetailedArea>($"areas/{areaId}");
    }
}
