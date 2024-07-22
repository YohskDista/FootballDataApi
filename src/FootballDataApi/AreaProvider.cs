using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Models.Areas;
using FootballDataApi.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi;

internal sealed class AreaProvider : IAreaProvider
{    
    private readonly HttpClient _httpClient;

    public AreaProvider(HttpClient httpClient)
        => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<IReadOnlyCollection<DetailedArea>> GetAllAreasAsync(
        CancellationToken cancellationToken = default)
    {
        var rootArea = await _httpClient.GetAsync<AreaRoot>("areas", cancellationToken);

        return rootArea.Areas;
    }

    public Task<AreaTreeStructure> GetAreaByIdAsync(
        int areaId, 
        CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(areaId, 0);

        return _httpClient.GetAsync<AreaTreeStructure>($"areas/{areaId}", cancellationToken);
    }
}
