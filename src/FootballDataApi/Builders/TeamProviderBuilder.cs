using System;
using System.Net.Http;

namespace FootballDataApi.Builders;

public class TeamProviderBuilder
{
    private HttpClient _httpClient;

    internal TeamProviderBuilder()
    {

    }

    public TeamProviderBuilder With(HttpClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        _httpClient = client;
        return this;
    }

    public TeamProvider Build()
    {
        return new TeamProvider(_httpClient);
    }
}
