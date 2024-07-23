using System;

namespace FootballDataApi.Extensions;

internal static class HttpHelpers
{
    public static string AddFiltersToUrl(string baseUrl, string[] filters)
    {
        if (filters.Length is 0)
        {
            return baseUrl;
        }

        if (filters.Length % 2 != 0)
        {
            throw new ArgumentException("Respect the key / value in filters (args=value)");
        }

        var urlWithFilters = $"{baseUrl}/?";

        for (int i = 0; i < filters.Length; i += 2)
        {
            urlWithFilters = $"{urlWithFilters}{filters[i]}={filters[i + 1]}&";
        }

        urlWithFilters = urlWithFilters.Remove(urlWithFilters.Length - 1);

        return urlWithFilters;
    }
}
