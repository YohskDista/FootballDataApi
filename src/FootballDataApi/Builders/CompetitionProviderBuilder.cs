using System;
using System.Net.Http;

namespace FootballDataApi.Builders;

public class CompetitionProviderBuilder
{
    private HttpClient _httpClient;

    internal CompetitionProviderBuilder()
    {

    }

    public CompetitionProviderBuilder With(HttpClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        _httpClient = client;
        return this;
    }

    public CompetitionProvider Build()
    {
        return new CompetitionProvider(_httpClient);
    }
}
