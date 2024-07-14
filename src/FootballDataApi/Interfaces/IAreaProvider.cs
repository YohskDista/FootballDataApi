using FootballDataApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Interfaces;

public interface IAreaProvider
{
    Task<IEnumerable<Area>> GetAllAreas();

    Task<Area> GetAreaById(int idArea);
}
