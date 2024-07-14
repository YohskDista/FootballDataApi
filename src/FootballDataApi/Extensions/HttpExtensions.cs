using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FootballDataApi.Extensions;

public static class HttpExtensions
{
    public static async Task<T> Get<T>(this HttpClient httpClient, HttpRequestMessage request)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(request);

        using (var response = await httpClient.SendAsync(request, new CancellationToken()))
        {
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}