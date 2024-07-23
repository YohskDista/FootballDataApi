using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Models.Competitions;
using FootballDataApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi;

internal sealed class CompetitionProvider : ICompetitionProvider
{
    private readonly IDataProvider _dataProvider;

    public CompetitionProvider(IDataProvider dataProvider)
        => _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));

    public async Task<IReadOnlyCollection<AvailableCompetition>> GetAvailableCompetitionsAsync(
        CancellationToken cancellationToken = default)
    {
        var competitionRoot = await _dataProvider.GetAsync<CompetitionRoot>("competitions");

        return competitionRoot.Competitions;
    }

    public async Task<IReadOnlyCollection<AvailableCompetition>> GetAvailableCompetitionsByAreaAsync(
        IEnumerable<int> areaIds,
        CancellationToken cancellationToken = default)
    {
        if (areaIds is null)
        {
            throw new ArgumentNullException(nameof(areaIds));
        }

        var urlWithFilters = HttpHelpers.AddFiltersToUrl(
            "competitions", 
            ["area", string.Join(',', areaIds)]);

        var competitionRoot = await _dataProvider.GetAsync<CompetitionRoot>(
            urlWithFilters, 
            cancellationToken);

        return competitionRoot.Competitions;
    }

    public Task<DetailedCompetition> GetCompetitionAsync(
        string competitionId, 
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(competitionId);

        return _dataProvider.GetAsync<DetailedCompetition>(
            $"competitions/{competitionId}", 
            cancellationToken);
    }
}
