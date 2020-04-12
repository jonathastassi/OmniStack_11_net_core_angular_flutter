using System.Threading.Tasks;
using Backend.Api.Database;

namespace Backend.Api.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DatabaseContext context;

        public BaseRepository(
            DatabaseContext context
        )
        {
            this.context = context;
        }

        protected async Task Save()
        {
            await this.context.SaveChangesAsync();
        }
    }
}