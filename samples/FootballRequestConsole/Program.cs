using FootballDataApi.Extensions;
using FootballDataApi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddFootballDataService(builder.Configuration["FootballData:ApiKey"]);

var host = builder.Build();

var areaProvider = host.Services.GetRequiredService<IAreaProvider>();
var competitionProvider = host.Services.GetRequiredService<ICompetitionProvider>();
var matchProvider = host.Services.GetRequiredService<IMatchProvider>();
var standingProvider = host.Services.GetRequiredService<IStandingProvider>();
var teamProvider = host.Services.GetRequiredService<ITeamProvider>();

await host.RunAsync();