using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Models.Competitions;
using FootballDataApi.Models.Scorers;
using FootballDataApi.Models.Teams;
using FootballDataApi.Services;
using System;
using System.Collections.Generic;
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

    public async Task<IReadOnlyCollection<FullDetailedTeam>> GetCompetitionTeamsAsync(
        string competitionId, 
        int? season = null, 
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(competitionId);

        var filters = new List<string>();

        if (season is not null)
        {
            filters.AddRange([nameof(season), $"{season}"]);
        }

        var url = HttpHelpers.AddFiltersToUrl(
            $"competitions/{competitionId}/teams",
            filters.ToArray());

        var teamsByCompetitionRoot = await _dataProvider.GetAsync<TeamsByCompetitionRoot>(
            url,
            cancellationToken);

        return teamsByCompetitionRoot.Teams;
    }

    public async Task<IReadOnlyCollection<Scorer>> GetScorersForCompetitionAsync(
        string competitionId, 
        int? season = null, 
        int? matchDay = null, 
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(competitionId);

        var filters = new List<string>();

        if (season is not null)
        {
            filters.AddRange([nameof(season), $"{season}"]);
        }

        if (matchDay is not null)
        {
            filters.AddRange([nameof(matchDay), $"{matchDay}"]);
        }

        var url = HttpHelpers.AddFiltersToUrl(
            $"competitions/{competitionId}/scorers",
            filters.ToArray()); 
        
        var scorerRoot = await _dataProvider.GetAsync<ScorerRoot>(
            url,
            cancellationToken);

        return scorerRoot.Scorers;
    }
}
