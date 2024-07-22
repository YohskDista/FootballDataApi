using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Models.Areas;
using FootballDataApi.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FootballDataApi.Tests.AreaTests;

public class AreaSource : IAreaProvider
{
    private AreaRoot _rootArea;

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
            var rootAreas = JsonConvert.DeserializeObject<AreaRoot>(areas);
            _rootArea = rootAreas;
        }
    }

    public Task<IReadOnlyCollection<DetailedArea>> GetAllAreas()
    {
        return Task.Run(() => _rootArea.Areas);
    }

    public Task<DetailedArea> GetAreaById(int areaId)
    {
        HttpHelpers.VerifyActionParameters(areaId, null, null);

        return Task.Run(() => _rootArea.Areas
            .FirstOrDefault(T => T.Id == areaId));
    }
}
