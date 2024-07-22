using FootballDataApi.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface IAreaProvider
{
    Task<IReadOnlyCollection<DetailedArea>> GetAllAreasAsync(
        CancellationToken cancellationToken = default);

    Task<AreaTreeStructure> GetAreaByIdAsync(
        int areaId, 
        CancellationToken cancellationToken = default);
}
