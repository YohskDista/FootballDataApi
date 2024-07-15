using FootballDataApi.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace FootballDataApi.Extensions;

public static class ServiceCollectionExtensions
{
    private static readonly string ApiBaseAddress = "http://api.football-data.org/v2/";

    public static IServiceCollection AddFootballDataService(this IServiceCollection serviceCollection, string apiKey)
    {
        ArgumentNullException.ThrowIfNull(serviceCollection);

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new ArgumentException(
                "You cannot use this API without an API key configured.", 
                nameof(apiKey));
        }

        return serviceCollection.AddSingleton(new HttpClient()
            {
                BaseAddress = new Uri(ApiBaseAddress)
            })
            .AddSingleton<IAreaProvider, AreaProvider>()
            .AddSingleton<ICompetitionProvider, CompetitionProvider>()
            .AddSingleton<IMatchProvider, MatchProvider>()
            .AddSingleton<IStandingProvider, StandingProvider>()
            .AddSingleton<ITeamProvider, TeamProvider>();
    }
}
