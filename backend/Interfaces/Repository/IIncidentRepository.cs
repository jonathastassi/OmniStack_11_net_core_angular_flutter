using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Interfaces.BaseRepository;
using backend.Models;

namespace backend.Interfaces.Repository
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