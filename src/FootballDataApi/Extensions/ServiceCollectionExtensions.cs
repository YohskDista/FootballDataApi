using FootballDataApi.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace FootballDataApi.Extensions;

public static class ServiceCollectionExtensions
{
    private static readonly string ApiBaseAddress = "http://api.football-data.org/v4/";

    public static IServiceCollection AddFootballDataService(this IServiceCollection serviceCollection, string apiKey)
    {
        ArgumentNullException.ThrowIfNull(serviceCollection);

        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(ApiBaseAddress)
        };

        if (!string.IsNullOrWhiteSpace(apiKey))
        {
            httpClient.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
        }

        return serviceCollection.AddSingleton(httpClient)
                                .AddSingleton<IAreaProvider, AreaProvider>()
                                .AddSingleton<ICompetitionProvider, CompetitionProvider>()
                                .AddSingleton<IMatchProvider, MatchProvider>()
                                .AddSingleton<IStandingProvider, StandingProvider>()
                                .AddSingleton<ITeamProvider, TeamProvider>();
    }
}
