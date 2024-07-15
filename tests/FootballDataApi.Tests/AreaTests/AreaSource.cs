using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Services;
using FootballDataApi.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FootballDataApi.Tests.AreaTests;

public class AreaSource : IAreaProvider
{
    private RootArea _rootArea;

    public AreaSource()
    {
        InitializeData();
    }

    private void InitializeData()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "FootballDataApi.Tests.Data.AreaData.json";

        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        using (StreamReader reader = new StreamReader(stream))
        {
            string areas = reader.ReadToEnd();
            var rootAreas = JsonConvert.DeserializeObject<RootArea>(areas);
            _rootArea = rootAreas;
        }
    }

    public Task<IEnumerable<Area>> GetAllAreas()
    {
        return Task.Run(() => _rootArea.Areas);
    }

    public Task<Area> GetAreaById(int idArea)
    {
        HttpHelpers.VerifyActionParameters(idArea, null, null);

        return Task.Run(() => _rootArea.Areas
            .FirstOrDefault(T => T.Id == idArea));
    }
}
