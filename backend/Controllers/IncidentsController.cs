using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly DatabaseContext context;

        public IncidentsController(
            DatabaseContext context
        )
        {
            this.context = context;
        }

        // GET api/incidents
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1)
        {
            try
            {
                int count = this.context.Incidents.Count();

                Response.Headers.Add("X-Total-Count", count.ToString());
                return Ok(await this.context.Incidents.Include(x => x.Ong).Skip((page - 1) * 5).Take(5).AsNoTracking().ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/incidents
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Incident incident, [FromHeader] string authorization)
        {
            try
            {
                if (string.IsNullOrEmpty(authorization))
                {
                    return Unauthorized();
                }

                incident.OngId = authorization;
                this.context.Incidents.Add(incident);

                await this.context.SaveChangesAsync();

                return Ok(new { Id = incident.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/incidents/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromHeader] string authorization)
        {
            try
            {
                Incident model = await this.context.Incidents.FirstOrDefaultAsync(x => x.Id == id);

                if (model.OngId != authorization)
                {
                    return Unauthorized();
                }

                this.context.Incidents.Remove(model);

                await this.context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}