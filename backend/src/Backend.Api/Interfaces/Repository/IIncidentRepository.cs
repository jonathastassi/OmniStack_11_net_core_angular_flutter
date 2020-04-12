using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Api.Interfaces.BaseRepository;
using Backend.Api.Models;

namespace Backend.Api.Interfaces.Repository
{
    public interface IIncidentRepository :
        IGetPaginatedRepository<Incident>,
        IInsertRepository<Incident, Incident>,
        IRemoveRepository<Incident>,
        IGetRepository<Incident>
    {
        Task<IEnumerable<Incident>> GetByOngId(string ongId);
    }
}