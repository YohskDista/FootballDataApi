# FootballDataApi

This library simplify the access to the [football-data API](https://www.football-data.org/) in C#. To begin you must obtain an API key on the football-data.org website. This library can access with a free account as well as a paid account.

The library is not official, the owner of the `Football Data API` is not responsible of the development.

# Build info & NuGet

[![Build status](https://ci.appveyor.com/api/projects/status/hnfqhf5lq4n1ibf2?svg=true)](https://ci.appveyor.com/project/YohskDista/footballdataapi)
[![NuGet](https://img.shields.io/nuget/v/FootballDataApi.svg)](https://www.nuget.org/packages/FootballDataApi/)

# Different kind of provider

The `Provider` services allow to access to the API of football-data. Here is the list of all available provider :

* IAreaProvider
  * Get all areas
  * Get an area by id
* ICompetitionProvider
  * Get all available competition (restricted if you are with a free account)
  * Get available competition by area
  * Get competition by id
* IMatchProvider
  * Get all matches
  * Get all matches of a specific team
  * Get all matches of a specific competition
  * Get a match by ID
* IStandingProvider
  * Get the ranking team of a specific competition
* ITeamProvider
  * Get all clubs of a competition
  * Get a club by ID
  
# Use the library

Starting V3.0.0 of the library, you will need an IoC and use dependency injection to be able to use the services. This upgrade was made to simplify the integration of the library into new projects.

To use the library you need to install the [NuGet package](https://www.nuget.org/packages/FootballDataApi/) in your project and add the services to your IoC.

```csharp
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddFootballDataService("[FootballDataApiKey]");
```

To generate the API key, create an account [here](https://www.football-data.org/client/register) and pass the API key to the `AddFootballDataService` method.

Then you will be able to resolve the provider services and to get information from the API. You can find a little example below:

```csharp
var areaProvider = host.Services.GetRequiredService<IAreaProvider>();

var areas = await areaProvider.GetAllAreas();

Console.WriteLine(areas)
```

Otherwise you can consult the samples present in this library.