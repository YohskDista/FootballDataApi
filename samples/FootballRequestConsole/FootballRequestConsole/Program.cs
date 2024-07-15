using FootballDataApi.Extensions;
using FootballDataApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddFootballDataService(string.Empty);

var host = builder.Build();

var areaProvider = host.Services.GetRequiredService<IAreaProvider>();

var result = await areaProvider.GetAllAreas();

await host.RunAsync();