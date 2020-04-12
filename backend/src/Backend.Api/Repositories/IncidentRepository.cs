using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.Database;
using Backend.Api.Interfaces.Repository;
using Backend.Api.Models;
using Backend.Api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Repositories
{
    public class IncidentRepository :
        BaseRepository,
        IIncidentRepository
    {
        public IncidentRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Incident> Get(Incident args)
        {
            return await this.context.Incidents.FirstOrDefaultAsync(x => x.Id == args.Id);
        }

        public async Task<IEnumerable<Incident>> GetByOngId(string ongId)
        {
            return await this.context.Incidents.Where(x => x.OngId == ongId).AsNoTracking().ToListAsync();
        }

        public async Task<DataPaginated> GetPaginated(int page)
        {
            int count = await this.context.Incidents.CountAsync();
            IEnumerable<Incident> data = await this.context.Incidents.Include(x => x.Ong).Skip((page - 1) * 5).Take(5).AsNoTracking().ToListAsync();

            return new DataPaginated(count, data);
        }

        public async Task<Incident> Insert(Incident entity)
        {
            this.context.Incidents.Add(entity);
            await this.Save();
            return entity;
        }

        public async Task<bool> Remove(Incident entity)
        {
            this.context.Incidents.Remove(entity);
            return await this.context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}