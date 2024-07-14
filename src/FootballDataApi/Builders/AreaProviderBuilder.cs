using System;
using System.Net.Http;

namespace FootballDataApi.Builders;

public class AreaProviderBuilder
{
    private HttpClient _httpClient;

    internal AreaProviderBuilder()
    {

    }

    public AreaProviderBuilder With(HttpClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        _httpClient = client;
        return this;
    }

    public AreaProvider Build()
    {
        return new AreaProvider(_httpClient);
    }
}
