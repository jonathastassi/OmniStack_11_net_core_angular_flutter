using System.Threading.Tasks;
using backend.Models;

namespace backend.Interfaces.Repository
{
    public interface IInsertRepository<I, O> where I : Entity
    {
        Task<O> Insert(I entity);
    }
}