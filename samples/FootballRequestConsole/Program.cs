using FootballDataApi.Extensions;
using FootballDataApi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddFootballDataService(builder.Configuration["FootballData:ApiKey"]);

var host = builder.Build();

//var areaProvider = host.Services.GetRequiredService<IAreaProvider>();
var competitionProvider = host.Services.GetRequiredService<ICompetitionProvider>();
//var matchProvider = host.Services.GetRequiredService<IMatchProvider>();
//var standingProvider = host.Services.GetRequiredService<IStandingProvider>();
//var teamProvider = host.Services.GetRequiredService<ITeamProvider>();

var availableCompetitions = await competitionProvider.GetAvailableCompetition();
var competition = await competitionProvider.GetCompetition("PL");
var competitionArea = await competitionProvider.GetAvailableCompetitionByArea(2114);

await host.RunAsync();