using System.Threading.Tasks;
using Backend.Api.Models;

namespace Backend.Api.Interfaces.BaseRepository
{
    public interface IRemoveRepository<I> where I : Entity
    {
        Task<bool> Remove(I entity);
    }
}