﻿using FootballDataApi.Extensions;
using FootballDataApi.Models.Competitions;
using FootballDataApi.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi;

internal sealed class CompetitionProvider : ICompetitionProvider
{
    private readonly HttpClient _httpClient;

    public CompetitionProvider(HttpClient httpClient) 
        => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<IReadOnlyCollection<AvailableCompetition>> GetAvailableCompetitionsAsync(
        CancellationToken cancellationToken = default)
    {
        var competitionRoot = await _httpClient.GetAsync<CompetitionRoot>("competitions");

        return competitionRoot.Competitions;
    }

    public async Task<IReadOnlyCollection<AvailableCompetition>> GetAvailableCompetitionsByAreaAsync(
        int areaId,
        CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(areaId, 0);

        var competitionRoot = await _httpClient.GetAsync<CompetitionRoot>(
            $"competitions?areas={areaId}", 
            cancellationToken);

        return competitionRoot.Competitions;
    }

    public Task<DetailedCompetition> GetCompetitionAsync(
        string competitionId, 
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(competitionId);

        return _httpClient.GetAsync<DetailedCompetition>(
            $"competitions/{competitionId}", 
            cancellationToken);
    }
}
