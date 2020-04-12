using System.Threading.Tasks;
using Backend.Api.Models;

namespace Backend.Api.Interfaces.Repository
{
    public interface IInsertRepository<I, O> where I : Entity
    {
        Task<O> Insert(I entity);
    }
}