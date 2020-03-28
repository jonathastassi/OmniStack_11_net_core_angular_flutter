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
    public class SessionController : ControllerBase
    {
        private readonly DatabaseContext context;

        public SessionController(
            DatabaseContext context
        )
        {
            this.context = context;
        }

        // POST api/session
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] OngLogin ong)
        {
            try
            {
                if (string.IsNullOrEmpty(ong.Id))
                {
                    return BadRequest();
                }

                Ong model = await this.context.Ongs.FirstOrDefaultAsync(x => x.Id == ong.Id);

                if (model == null)
                {
                    return BadRequest();
                }

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}