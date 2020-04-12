using System.Threading.Tasks;
using Backend.Api.Models;

namespace Backend.Api.Interfaces.Repository
{
    public interface IOngRepository :
        IInsertRepository<Ong, Ong>,
        IGetAllRepository<Ong>
    {
        Task<Ong> GetByEmail(string email);
    }
}