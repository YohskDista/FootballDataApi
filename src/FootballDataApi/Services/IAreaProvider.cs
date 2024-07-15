using FootballDataApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface IAreaProvider
{
    Task<IReadOnlyCollection<Area>> GetAllAreas();

    Task<Area> GetAreaById(int areaId);
}
