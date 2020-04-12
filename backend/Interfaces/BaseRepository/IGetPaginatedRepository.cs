using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using backend.ViewModels;

namespace backend.Interfaces.BaseRepository
{
    public interface IGetPaginatedRepository<I> where I : Entity
    {
        Task<DataPaginated> GetPaginated(int page);
    }
}