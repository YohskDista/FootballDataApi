using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

internal sealed class DataProvider(HttpClient httpClient) : IDataProvider
{
    private readonly HttpClient _httpClient = 
        httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<T> GetAsync<T>(string requestUri, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(requestUri);

        var response = await httpClient.GetAsync(requestUri, cancellationToken);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonConvert.DeserializeObject<T>(content);
    }
}
