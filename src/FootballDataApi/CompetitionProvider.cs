using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi
{
    public class CompetitionProvider
    {
        private readonly ICompetition _competitionDataSource;

        public CompetitionProvider(ICompetition competitionDataSource)
        {
            _competitionDataSource = competitionDataSource;
        }

        public async Task<IEnumerable<Competition>> GetAvailableCompetition()
        {
            return await _competitionDataSource.GetAvailableCompetition();
        }

        public async Task<IEnumerable<Competition>> GetAvailableCompetitionByArea(int areaId)
        {
            HttpHelpers.VerifyActionParameters(areaId, null, null);
            return await _competitionDataSource.GetAvailableCompetitionByArea(areaId);
        }

        public async Task<Competition> GetCompetition(int idCompetition)
        {
            HttpHelpers.VerifyActionParameters(idCompetition, null, null);
            return await _competitionDataSource.GetCompetition(idCompetition);
        }
    }
}
