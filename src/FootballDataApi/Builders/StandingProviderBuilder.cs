using System;
using System.Net.Http;

namespace FootballDataApi.Builders;

public class StandingProviderBuilder
{
    private HttpClient _httpClient;

    internal StandingProviderBuilder()
    {

    }

    public StandingProviderBuilder With(HttpClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        _httpClient = client;
        return this;
    }

    public StandingProvider Build()
    {
        return new StandingProvider(_httpClient);
    }
}
