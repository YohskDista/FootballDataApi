using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Models.Matches;
using FootballDataApi.Models.Persons;
using FootballDataApi.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi;

internal sealed class PersonProvider : IPersonProvider
{
    private readonly IDataProvider _dataProvider;

    public PersonProvider(IDataProvider dataProvider)
        => _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));

    public Task<FullDetailedPerson> GetPersonByIdAsync(
        int personId, 
        CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(personId, 0);

        return _dataProvider.GetAsync<FullDetailedPerson>($"persons/{personId}", cancellationToken);
    }

    public async Task<IReadOnlyCollection<Match>> GetPersonMatchesAsync(
        int personId, 
        Lineup? lineup = null, 
        PlayerAction? playerAction = null, 
        DateTime? dateFrom = null, 
        DateTime? dateTo = null, 
        IEnumerable<string>? competitions = null, 
        int limit = 100, 
        int offset = 100, 
        CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(personId, 0);

        if (dateTo.HasValue)
        {
            if (!dateFrom.HasValue)
            {
                throw new ArgumentException(
                    "You cannot set the dateTo parameter without dateFrom.", nameof(dateFrom));
            }

            if (dateTo < dateFrom)
            {
                throw new ArgumentException("dateTo cannot be before dateFrom.", nameof(dateTo));
            }
        }

        if (limit is < 1 or > 100)
        {
            throw new ArgumentOutOfRangeException(
                nameof(limit), limit, "The value must be between [1, 100]");
        }

        if (offset is < 1 or > 100)
        {
            throw new ArgumentOutOfRangeException(
                nameof(offset), offset, "The value must be between [1, 100]");
        }

        var filters = new List<string>
        {
            nameof(limit), $"{limit}", nameof(offset), $"{offset}"
        };

        if (lineup is not null)
        {
            filters.AddRange([nameof(lineup), $"{lineup}"]);
        }

        if (playerAction is not null)
        {
            filters.AddRange([nameof(playerAction), $"{playerAction}"]);
        }

        if (dateFrom is not null)
        {
            filters.AddRange([nameof(dateFrom), dateFrom?.ToString("yyyy-MM-dd")]);
        }

        if (dateTo is not null)
        {
            filters.AddRange([nameof(dateTo), dateTo?.ToString("yyyy-MM-dd")]);
        }

        if (competitions is not null)
        {
            filters.AddRange([nameof(competitions), string.Join(',', competitions)]);
        }

        var url = $"persons/{personId}/matches";

        url = HttpHelpers.AddFiltersToUrl(url, filters.ToArray());

        var root = await _dataProvider.GetAsync<PersonMatchRoot>(url, cancellationToken);

        return root.Matches;
    }
}
