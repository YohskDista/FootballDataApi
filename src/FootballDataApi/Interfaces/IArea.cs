using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi.Interfaces
{
    public interface IArea
    {
        Task<IEnumerable<Area>> GetAllAreas();

        Task<Area> GetAreaById(int idArea);
    }
}
