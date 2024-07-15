using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FootballDataApi.Extensions;

public static class HttpExtensions
{
    public static async Task<T> GetAsync<T>(this HttpClient httpClient, string requestUri)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(requestUri);

        var response = await httpClient.GetAsync(requestUri);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<T>(content);
    }
}