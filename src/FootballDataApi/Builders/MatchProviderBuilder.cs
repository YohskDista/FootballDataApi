using System;
using System.Net.Http;

namespace FootballDataApi.Builders;

public class MatchProviderBuilder
{
    private HttpClient _httpClient;

    internal MatchProviderBuilder()
    {

    }

    public MatchProviderBuilder With(HttpClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        _httpClient = client;
        return this;
    }

    public MatchProvider Build()
    {
        return new MatchProvider(_httpClient);
    }
}
