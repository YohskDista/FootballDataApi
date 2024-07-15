using FootballDataApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface IAreaProvider
{
    Task<IEnumerable<Area>> GetAllAreas();

    Task<Area> GetAreaById(int areaId);
}
