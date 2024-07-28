using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Models.Competitions;
using FootballDataApi.Models.Matches;
using FootballDataApi.Models.Scorers;
using FootballDataApi.Models.Teams;
using FootballDataApi.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        IEnumerable<int> areas,
        CancellationToken cancellationToken = default)
    {
        if (areas is null)
        {
            throw new ArgumentNullException(nameof(areas));
        }

        var urlWithFilters = HttpHelpers.AddFiltersToUrl(
            "competitions", 
            [nameof(areas), string.Join(',', areas)]);

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
            ArgumentOutOfRangeException.ThrowIfLessThan((int)season, 0);

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
            ArgumentOutOfRangeException.ThrowIfLessThan((int)season, 0);

            filters.AddRange([nameof(season), $"{season}"]);
        }

        if (matchDay is not null)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan((int)matchDay, 0);

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

    public Task<IReadOnlyCollection<Match>> GetAllMatchesOfCompetitionAsync(
        string competitionId, 
        int? season = null, 
        int? matchDay = null, 
        Status? status = null, 
        Stage? stage = null, 
        Group? group = null, 
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(competitionId);

        return GetMatchesWithFilters(
            competitionId,
            Array.Empty<string>(),
            season,
            matchDay,
            status,
            stage,
            group,
            cancellationToken);
    }

    public Task<IReadOnlyCollection<Match>> GetAllMatchesOfCompetitionBetweenAsync(
        string competitionId, 
        DateTime dateFrom, 
        DateTime dateTo, 
        Status? status = null, 
        Stage? stage = null, 
        Group? group = null, 
        CancellationToken cancellationToken = default)
     {
        ArgumentException.ThrowIfNullOrWhiteSpace(competitionId);

        if (dateTo < dateFrom)
        {
            throw new ArgumentException("dateTo cannot be before dateFrom.", nameof(dateTo));
        }

        var filters = new string[]
        {
            nameof(dateFrom), 
            dateFrom.ToString("yyyy-MM-dd"),
            nameof(dateTo), 
            dateTo.ToString("yyyy-MM-dd")
        };

        return GetMatchesWithFilters(
            competitionId,
            filters,
            status: status, 
            stage: stage, 
            group: group,
            cancellationToken: cancellationToken);
    }

    private async Task<IReadOnlyCollection<Match>> GetMatchesWithFilters(
        string competitionId,
        string[] existingFilters,
        int? season = null,
        int? matchDay = null,
        Status? status = null,
        Stage? stage = null,
        Group? group = null,
        CancellationToken cancellationToken = default)
    {
        var filters = new List<string>();

        if (season is not null)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan((int)season, 0);

            filters.AddRange([nameof(season), $"{season}"]);
        }

        if (matchDay is not null)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan((int)matchDay, 0);

            filters.AddRange([nameof(matchDay), $"{matchDay}"]);
        }

        if (status is not null)
        {
            if (!Enum.IsDefined((Status)status))
            {
                throw new InvalidEnumArgumentException(nameof(status), (int)status, typeof(Status));
            }

            filters.AddRange([nameof(stage), $"{stage}"]);
        }

        if (stage is not null)
        {
            if (!Enum.IsDefined((Stage)stage))
            {
                throw new InvalidEnumArgumentException(nameof(stage), (int)stage, typeof(Stage));
            }

            filters.AddRange([nameof(stage), $"{stage}"]);
        }

        if (group is not null)
        {
            if (!Enum.IsDefined((Group)group))
            {
                throw new InvalidEnumArgumentException(nameof(group), (int)group, typeof(Group));
            }

            filters.AddRange([nameof(group), $"{group}"]);
        }

        var url = HttpHelpers.AddFiltersToUrl(
            $"competitions/{competitionId}/matches", 
            filters.Concat(existingFilters).ToArray());

        var rootMatches = await _dataProvider.GetAsync<MatchRoot>(url, cancellationToken);

        return rootMatches.Matches;
    }
}
