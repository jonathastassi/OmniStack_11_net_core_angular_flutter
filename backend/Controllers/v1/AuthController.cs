using System;
using System.Threading.Tasks;
using backend.Dtos;
using backend.Interfaces.Repository;
using backend.Models;
using backend.Services;
using backend.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOngRepository ongRepository;

        public AuthController(
            IOngRepository ongRepository
        )
        {
            this.ongRepository = ongRepository;
        }

        // POST api/v1/auth/login
        /// <summary>
        /// Rota para autenticar na API e gerar o token JWT.
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] OngLogin ong)
        {
            try
            {

                Ong model = await this.ongRepository.GetByEmail(ong.Email);

                if (BCrypt.Net.BCrypt.Verify(ong.Password, model.Password))
                {
                    string token = TokenService.GenerateToken(model);

                    return Ok(new UserAuthenticated(model.GetOng(), token));
                }

                return BadRequest("Login inválido");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/v1/auth/register
        /// <summary>
        /// Rota para registrar uma nova ONG na API.
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Ong model)
        {
            try
            {
                model.HashPassword();
                await this.ongRepository.Insert(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}