using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OngsController : ControllerBase
    {
        private readonly DatabaseContext context;

        public OngsController(
            DatabaseContext context
        )
        {
            this.context = context;
        }

        // GET api/ongs
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await this.context.Ongs.AsNoTracking().ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/ongs
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ong ong)
        {
            try
            {
                ong.Id = Guid.NewGuid().ToString().Substring(0, 8);

                this.context.Ongs.Add(ong);

                await this.context.SaveChangesAsync();

                return Ok(new { Id = ong.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}