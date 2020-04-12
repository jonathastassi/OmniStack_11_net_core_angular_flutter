using System.Threading.Tasks;
using backend.Models;

namespace backend.Interfaces.Repository
{
    public interface IGetRepository<I> where I : Entity
    {
        Task<I> Get(I args);
    }
}