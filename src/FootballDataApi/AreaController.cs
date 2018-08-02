using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi
{
    public class AreaController
    {
        private readonly IArea _areaDataSource;

        public AreaController(IArea areaDataSource)
        {
            _areaDataSource = areaDataSource;
        }

        public async Task<IEnumerable<Area>> GetAllAreas()
        {
            return await _areaDataSource.GetAllAreas();
        }

        public async Task<Area> GetAreaById(int idArea)
        {
            HttpExtensions.VerifyActionParameters(idArea, null, null);

            return await _areaDataSource.GetAreaById(idArea);
        }
    }
}
