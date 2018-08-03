using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi
{
    public class StandingController
    {
        private readonly IStanding _standingDataSource;

        public StandingController(IStanding standingDataSource)
        {
            _standingDataSource = standingDataSource;
        }

        public async Task<SeasonStanding> GetStandingOfCompetition(int idCompetition)
        {
            HttpExtensions.VerifyActionParameters(idCompetition, null, null);

            return await _standingDataSource.GetStandingOfCompetition(idCompetition);
        }
    }
}
