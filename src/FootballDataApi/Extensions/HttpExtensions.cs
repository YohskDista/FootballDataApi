using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FootballDataApi.Extensions;

public static class HttpExtensions
{
    public static async Task<T> GetAsync<T>(
        this HttpClient httpClient, 
        string requestUri, 
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(requestUri);

        var response = await httpClient.GetAsync(requestUri, cancellationToken);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonConvert.DeserializeObject<T>(content);
    }
}