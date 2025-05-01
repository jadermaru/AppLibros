using BackendLibreria.DTOs;
using BackendLibreria.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendLibreria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await _userService.CreateUserAsync(dto);

            if (token == null)
                return Conflict("El nombre de usuario ya existe.");

            return Ok(new { message = "Usuario creado correctamente.", token });
        }
    }
}
