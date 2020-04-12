using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Interfaces.Repository
{
    public interface IGetAllRepository<I> where I : Entity
    {
        Task<IEnumerable<I>> GetAll();
    }
}