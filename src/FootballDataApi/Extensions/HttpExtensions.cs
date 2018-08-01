using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FootballDataApi.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<T> Get<T>(this HttpClient httpClient, HttpRequestMessage request)
        {
            using (var response = await httpClient.SendAsync(request, new CancellationToken()))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
        }

        public static string AddFiltersToUrl(string baseUrl, string[] filters)
        {
            var urlWithFilters = $"{baseUrl}/?";
            for (int i = 0; i < filters.Length; i += 2)
            {
                urlWithFilters = $"{urlWithFilters}{filters[i]}={filters[i + 1]}&";
            }
            urlWithFilters = urlWithFilters.Remove(urlWithFilters.Length - 1);

            return urlWithFilters;
        }

        internal static IEnumerable<string> IsFilterPresentInList(this string[] authorizedFilters, string[] filters)
        {
            var parametersNotPresent = filters
                .Where((filter, index) => index % 2 == 0 &&
                    !authorizedFilters.Contains(filter))
                .ToList();

            return parametersNotPresent;
        }
    }
}