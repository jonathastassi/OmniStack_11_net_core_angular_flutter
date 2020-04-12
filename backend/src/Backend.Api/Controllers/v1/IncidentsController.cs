using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend.Api.Database;
using Backend.Api.Interfaces.Repository;
using Backend.Api.Models;
using Backend.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentRepository incidentRepository;

        public IncidentsController(
            IIncidentRepository incidentRepository
        )
        {
            this.incidentRepository = incidentRepository;
        }

        // GET api/v1/incidents
        /// <summary>
        /// Rota que retorna as ações cadastradas na API
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1)
        {
            try
            {
                DataPaginated data = await this.incidentRepository.GetPaginated(page);

                Response.Headers.Add("X-Total-Count", data.Count.ToString());
                return Ok(data.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/v1/incidents
        /// <summary>
        /// Rota que cadastrada ações na API
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Incident incident)
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.PrimarySid).Value;
                incident.SetOngAuthenticated(userId);
                await this.incidentRepository.Insert(incident);

                return Ok(new { Id = incident.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/v2/incidents/:id
        /// <summary>
        /// Rota que deleta ações na API
        /// </summary>
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.PrimarySid).Value;

                Incident model = await this.incidentRepository.Get(args: new Incident(id));
                if (model == null)
                {
                    return BadRequest("Nenhum registro encontrado");
                }

                if (model.OngId != userId)
                {
                    return Unauthorized();
                }

                if (await this.incidentRepository.Remove(model))
                {
                    return NoContent();
                }
                return BadRequest("Registro não removido");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}