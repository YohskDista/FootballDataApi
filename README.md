# FootballDataApi

This library is an unofficial who can access to the [football-data API](https://www.football-data.org/) in C#. To begin you must obtain an API key on the football-data.org website. This library can access with a free account as well as a paid account.

# Build info & NuGet

[![Build status](https://ci.appveyor.com/api/projects/status/hnfqhf5lq4n1ibf2?svg=true)](https://ci.appveyor.com/project/YohskDista/footballdataapi)
[![NuGet](https://img.shields.io/nuget/v/FootballDataApi.svg)](https://www.nuget.org/packages/FootballDataApi/)

# Different kind of provider

The `Provider` classes permitt to access to the API of football-data. Here is the list of all available provider :

* AreaProvider
  * Get all areas
  * Get an area by id
* CompetitionProvider
  * Get all available competition (restricted if you are with a free account)
  * Get available competition by area
  * Get competition by id
* MatchProvider
  * Get all matches
  * Get all matches of a specific team
  * Get all matches of a specific competition
  * Get a match by ID
* Standing provider
  * Get the ranking team of a specific competition
* TeamProvider
  * Get all clubs of a competition
  * Get a club by ID
  
# Use a provider
  
For using a provider you must first create an HTTP Client with the API key in header as described in [football-data API documentation](https://www.football-data.org/documentation/api). Here is an example :
  
```
var httpClient = new HttpClient();

httpClient.DefaultRequestHeaders.Add("X-Auth-Token", "[YourApiKey]");  
```

And then you can create a provider and call the method that you want :

```
var competitionController = CompetitionProvider.Create()
    .With(httpClient)
    .Build();  
    
var competitions = await competitionController.GetAvailableCompetition();

Console.WriteLine("### All available competitions ###");
Console.WriteLine(JsonConvert.SerializeObject(competitions));
Console.WriteLine();
```
