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
    public class ProfileController : ControllerBase
    {
        private readonly DatabaseContext context;

        public ProfileController(
            DatabaseContext context
        )
        {
            this.context = context;
        }

        // GET api/profile
        [HttpGet]
        public async Task<IActionResult> GetIncidents([FromHeader] string authorization)
        {
            try
            {
                if (string.IsNullOrEmpty(authorization))
                {
                    return Unauthorized();
                }

                var list = await this.context.Incidents.Where(x => x.OngId == authorization).AsNoTracking().ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}