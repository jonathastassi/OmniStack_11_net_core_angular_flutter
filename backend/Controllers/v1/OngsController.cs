using System;
using System.Threading.Tasks;
using backend.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class OngsController : ControllerBase
    {
        private readonly IOngRepository repository;

        public OngsController(
            IOngRepository repository
        )
        {
            this.repository = repository;
        }

        // GET api/v1/ongs
        /// <summary>
        /// Rota que retorna as ongs cadastradas na API.
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await this.repository.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}