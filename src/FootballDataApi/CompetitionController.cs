using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi
{
    public class CompetitionController
    {
        private readonly ICompetition _competitionDataSource;

        public CompetitionController(ICompetition competitionDataSource)
        {
            _competitionDataSource = competitionDataSource;
        }

        public Task<IEnumerable<Match>> GetAllMatchOfCompetition(int idCompetition, params string[] filters)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Competition>> GetAvailableCompetition()
        {
            return await _competitionDataSource.GetAvailableCompetition();
        }

        public async Task<IEnumerable<Competition>> GetAvailableCompetitionByArea(int areaId)
        {
            return await _competitionDataSource.GetAvailableCompetitionByArea(areaId);
        }

        public async Task<Competition> GetCompetition(int id)
        {
            return await _competitionDataSource.GetCompetition(id);
        }
    }
}
