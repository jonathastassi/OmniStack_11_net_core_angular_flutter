using System.Threading.Tasks;
using backend.Models;

namespace backend.Interfaces.BaseRepository
{
    public interface IRemoveRepository<I> where I : Entity
    {
        Task<bool> Remove(I entity);
    }
}