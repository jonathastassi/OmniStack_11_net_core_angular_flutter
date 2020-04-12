using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend.Api.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IIncidentRepository incidentRepository;

        public ProfileController(
            IIncidentRepository incidentRepository
        )
        {
            this.incidentRepository = incidentRepository;
        }

        // GET api/v1/profile
        /// <summary>
        /// Rota que retorna as açaões cadastradas pelo usuário autenticado.
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<IActionResult> GetIncidents()
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.PrimarySid).Value;
                var list = await this.incidentRepository.GetByOngId(userId);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}