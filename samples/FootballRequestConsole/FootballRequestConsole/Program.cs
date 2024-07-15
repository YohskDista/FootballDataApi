using FootballDataApi.Extensions;
using FootballDataApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddFootballDataService(string.Empty);

var host = builder.Build();

var areaProvider = host.Services.GetRequiredService<IAreaProvider>();
var competitionProvider = host.Services.GetRequiredService<ICompetitionProvider>();
var matchProvider = host.Services.GetRequiredService<IMatchProvider>();
var standingProvider = host.Services.GetRequiredService<IStandingProvider>();
var teamProvider = host.Services.GetRequiredService<ITeamProvider>();

var areas = await areaProvider.GetAllAreas();
var matches = await matchProvider.GetAllMatches();
var competitions = await competitionProvider.GetAvailableCompetition();
//var standings = await standingProvider.GetStandingOfCompetition(2019);
var teams = await teamProvider.GetTeamByCompetition(2114);

await host.RunAsync();