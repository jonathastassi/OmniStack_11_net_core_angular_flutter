using System.Threading.Tasks;
using backend.Models;

namespace backend.Interfaces.Repository
{
    public interface IOngRepository :
        IInsertRepository<Ong, Ong>,
        IGetAllRepository<Ong>
    {
        Task<Ong> GetByEmail(string email);
    }
}