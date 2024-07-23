using FootballDataApi.Models;
using FootballDataApi.Models.Matches;
using FootballDataApi.Models.Persons;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface IPersonProvider
{
    Task<FullDetailedPerson> GetPersonByIdAsync(int personId, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Match>> GetPersonMatchesAsync(
        int personId, 
        Lineup? lineup = null,
        PlayerAction? playerAction = null,
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        IEnumerable<string>? competitions = null,
        int limit = 100,
        int offset = 100,
        CancellationToken cancellationToken = default);
}