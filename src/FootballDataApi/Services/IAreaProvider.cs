using FootballDataApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface IAreaProvider
{
    Task<IReadOnlyCollection<DetailedArea>> GetAllAreas();

    Task<AreaTreeStructure> GetAreaById(int areaId);
}
