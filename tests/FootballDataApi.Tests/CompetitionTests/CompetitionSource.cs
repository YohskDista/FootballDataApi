﻿using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Services;
using FootballDataApi.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FootballDataApi.Tests.CompetitionTests;

public class CompetitionSource : ICompetitionProvider
{
    private IReadOnlyCollection<Competition> _listCompetitionMockup;

    public CompetitionSource()
    {
        InitializeData();
    }

    private void InitializeData()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "FootballDataApi.Tests.Data.CompetitionData.json";

        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        using (StreamReader reader = new StreamReader(stream))
        {
            string matches = reader.ReadToEnd();
            var rootCompetitions = JsonConvert.DeserializeObject<RootCompetition>(matches);
            _listCompetitionMockup = rootCompetitions.Competitions;
        }
    }

    public Task<IReadOnlyCollection<Competition>> GetAvailableCompetition()
    {
        return Task.Run(() => _listCompetitionMockup);
    }

    public Task<IReadOnlyCollection<Competition>> GetAvailableCompetitionByArea(int areaId)
    {
        HttpHelpers.VerifyActionParameters(areaId, null, null);

        return Task.Run(() => (IReadOnlyCollection<Competition>)_listCompetitionMockup
            .Where(T => T.Area.Id == areaId).ToArray());
    }

    public Task<Competition> GetCompetition(int competitionId)
    {
        HttpHelpers.VerifyActionParameters(competitionId, null, null);

        return Task.Run(() => _listCompetitionMockup
            .FirstOrDefault(T => T.Id == competitionId));
    }
}
