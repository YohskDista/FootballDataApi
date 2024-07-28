using FootballDataApi.Models;
using FootballDataApi.Models.Areas;
using FootballDataApi.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi;

internal sealed class AreaProvider : IAreaProvider
{    
    private readonly IDataProvider _dataProvider;

    public AreaProvider(IDataProvider dataProvider)
        => _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));

    public async Task<IReadOnlyCollection<DetailedArea>> GetAllAreasAsync(
        CancellationToken cancellationToken = default)
    {
        var rootArea = await _dataProvider.GetAsync<AreaRoot>("areas", cancellationToken);

        return rootArea.Areas;
    }

    public Task<AreaTreeStructure> GetAreaByIdAsync(
        int areaId, 
        CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(areaId, 0);

        return _dataProvider.GetAsync<AreaTreeStructure>($"areas/{areaId}", cancellationToken);
    }
}
