using Microsoft.AspNetCore.Mvc;
using sga.AuthService.DTOs;
using sga.AuthService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound(new { message = "Usuario no encontrado." });

            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDTO userDto)
        {
            if (userDto == null)
                return BadRequest(new { message = "Datos del usuario no válidos." });

            var success = await _userService.AddUserAsync(userDto);
            if (!success)
                return BadRequest(new { message = "No se pudo crear el usuario." });

            return Ok(userDto);
        }

        // PUT: api/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDto)
        {
            if (userDto == null)
                return BadRequest(new { message = "Datos del usuario no válidos." });

            var success = await _userService.UpdateUserAsync(id, userDto);
            if (!success)
                return NotFound(new { message = "Usuario no encontrado." });

            return NoContent();
        }

        // DELETE: api/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success)
                return NotFound(new { message = "Usuario no encontrado." });

            return NoContent();
        }
    }
}
