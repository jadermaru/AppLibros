using BackendLibreria.DTOs;
using BackendLibreria.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BackendLibreria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO dto)
        {
            var token = await _tokenService.AuthenticateAsync(dto.Username, dto.Password);

            if (token == null)
                return Unauthorized("Credenciales inválidas.");

            return Ok(new { token });
        }

        [Authorize]
        [HttpGet("validate")]
        public IActionResult ValidateToken()
        {
            // Si llegas aquí, el token fue validado por el middleware
            var userName = User.Identity?.Name;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok(new
            {
                valid = true,
                userName,
                userId
            });
        }

    }
}
