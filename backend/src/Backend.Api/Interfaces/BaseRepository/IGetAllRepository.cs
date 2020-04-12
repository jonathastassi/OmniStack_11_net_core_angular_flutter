using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Api.Models;

namespace Backend.Api.Interfaces.Repository
{
    public interface IGetAllRepository<I> where I : Entity
    {
        Task<IEnumerable<I>> GetAll();
    }
}