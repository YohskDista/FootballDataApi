using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Models.Matches;
using FootballDataApi.Services;

namespace FootballDataApi;

internal sealed class MatchProvider : IMatchProvider
{
    private readonly IDataProvider _dataProvider;

    public MatchProvider(IDataProvider dataProvider)
        => _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));

    public Task<Match> GetMatchByIdAsync(
        int matchId, 
        CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(matchId, 0);

        return _dataProvider.GetAsync<Match>($"matches/{matchId}", cancellationToken);
    }

    public Task<IReadOnlyCollection<Match>> GetMatchesAsync(
        IEnumerable<int>? ids = null, 
        DateTime? date = null, 
        Status? status = null, 
        CancellationToken cancellationToken = default)
    {
        var filters = new List<string>();

        if (date is not null)
        {
            filters.AddRange([nameof(date), date?.ToString("yyyy-MM-dd")]);
        }

        return GetMatchesWithFiltersAsync(filters.ToArray(), ids, status, cancellationToken);
    }

    public Task<IReadOnlyCollection<Match>> GetMatchesBetweenAsync(
        DateTime dateFrom, 
        DateTime dateTo, 
        IEnumerable<int>? ids = null, 
        Status? status = null, 
        CancellationToken cancellationToken = default)
    {
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

        return GetMatchesWithFiltersAsync(filters, ids, status, cancellationToken);
    }

    private async Task<IReadOnlyCollection<Match>> GetMatchesWithFiltersAsync(
        string[] existingFilters,
        IEnumerable<int>? ids = null, 
        Status? status = null, 
        CancellationToken cancellationToken = default)
    {
        var filters = new List<string>();

        if (ids is not null)
        {
            filters.AddRange([nameof(ids), string.Join(',', ids)]);
        }

        if (status is not null)
        {
            filters.AddRange([nameof(status), $"{status}"]);
        }

        var url = HttpHelpers.AddFiltersToUrl("matches", filters.Concat(existingFilters).ToArray());

        var rootMatches = await _dataProvider.GetAsync<MatchRoot>(url, cancellationToken);

        return rootMatches.Matches;
    }
}