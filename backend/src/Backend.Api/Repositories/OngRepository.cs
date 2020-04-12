using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Api.Database;
using Backend.Api.Interfaces.Repository;
using Backend.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Repositories
{
    public class OngRepository :
        BaseRepository,
        IOngRepository
    {
        public OngRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ong>> GetAll()
        {
            return await this.context.Ongs.AsNoTracking().ToListAsync();
        }

        public async Task<Ong> GetByEmail(string email)
        {
            return await this.context.Ongs.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Ong> Insert(Ong entity)
        {
            this.context.Ongs.Add(entity);
            await this.Save();
            return entity;
        }
    }
}