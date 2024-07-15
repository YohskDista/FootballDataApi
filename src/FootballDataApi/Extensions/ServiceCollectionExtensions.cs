using FootballDataApi.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace FootballDataApi.Extensions;

public static class ServiceCollectionExtensions
{
    private static readonly string ApiBaseAddress = "http://api.football-data.org/v2/";

    public static IServiceCollection AddFootballDataService(this IServiceCollection serviceCollection)
    {
        ArgumentNullException.ThrowIfNull(serviceCollection);

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
