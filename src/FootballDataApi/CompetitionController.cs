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
    public class CompetitionController
    {
        private readonly ICompetition _competitionDataSource;

        public CompetitionController(ICompetition competitionDataSource)
        {
            _competitionDataSource = competitionDataSource;
        }

        public async Task<IEnumerable<Match>> GetAllMatchOfCompetition(int idCompetition, params string[] filters)
        {
            var authorizedFilters = new string[] { "dateFrom", "dateTo", "stage", "status", "matchday", "group" };

            if (filters.Length > 0 && filters.Length % 2 != 0)
                throw new ArgumentException("Respect key value parameters.");

            if (idCompetition < 0)
                throw new IndexOutOfRangeException("Id competition cannot be negative");

            if(filters != null)
            {
                var parametersNotPresent = filters
                    .Where((filter, index) => index % 2 == 0 && 
                        !authorizedFilters.Contains(filter))
                    .ToList();

                if (parametersNotPresent.Count > 0)
                    throw new ArgumentException($"This filters are not supported : \n { string.Join("\n", parametersNotPresent) }");
            }

            return await _competitionDataSource.GetAllMatchOfCompetition(idCompetition, filters);
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
