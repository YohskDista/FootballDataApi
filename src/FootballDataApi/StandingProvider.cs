using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi
{
    public class StandingProvider
    {
        private readonly IStanding _standingDataSource;

        public StandingProvider(IStanding standingDataSource)
        {
            _standingDataSource = standingDataSource;
        }

        public async Task<SeasonStanding> GetStandingOfCompetition(int idCompetition)
        {
            HttpHelpers.VerifyActionParameters(idCompetition, null, null);

            return await _standingDataSource.GetStandingOfCompetition(idCompetition);
        }
    }
}
