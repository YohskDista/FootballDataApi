using FootballDataApi.Extensions;
using FootballDataApi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddFootballDataService(builder.Configuration["FootballData:ApiKey"]);

var host = builder.Build();

var areaProvider = host.Services.GetRequiredService<IAreaProvider>();
var competitionProvider = host.Services.GetRequiredService<ICompetitionProvider>();
//var matchProvider = host.Services.GetRequiredService<IMatchProvider>();
var standingProvider = host.Services.GetRequiredService<IStandingProvider>();
//var teamProvider = host.Services.GetRequiredService<ITeamProvider>();

//var area = await areaProvider.GetAreaById(2077);
//var areas = await areaProvider.GetAllAreas();
//var matches = await matchProvider.GetAllMatches();
var competitions = await competitionProvider.GetAvailableCompetition();
//var competition = await competitionProvider.GetCompetition(2019);
var standings = await standingProvider.GetStandingOfCompetition(2019);
//var teams = await teamProvider.GetTeamByCompetition(2019);

await host.RunAsync();