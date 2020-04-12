using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Api.Models;
using Backend.Api.ViewModels;

namespace Backend.Api.Interfaces.BaseRepository
{
    public interface IGetPaginatedRepository<I> where I : Entity
    {
        Task<DataPaginated> GetPaginated(int page);
    }
}