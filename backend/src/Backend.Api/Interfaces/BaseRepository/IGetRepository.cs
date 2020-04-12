using System.Threading.Tasks;
using Backend.Api.Models;

namespace Backend.Api.Interfaces.Repository
{
    public interface IGetRepository<I> where I : Entity
    {
        Task<I> Get(I args);
    }
}