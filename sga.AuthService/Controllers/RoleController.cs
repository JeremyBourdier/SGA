using Microsoft.AspNetCore.Mvc;
using sga.AuthService.DTOs;
using sga.AuthService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        // GET: api/role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRole(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
                return NotFound(new { message = "Rol no encontrado." });

            return Ok(role);
        }

        // POST: api/role
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] RoleDTO roleDto)
        {
            if (roleDto == null)
                return BadRequest(new { message = "Datos del rol no válidos." });

            var success = await _roleService.AddRoleAsync(roleDto);
            if (!success)
                return BadRequest(new { message = "No se pudo crear el rol." });

            return Ok(roleDto);
        }

        // PUT: api/role/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleDTO roleDto)
        {
            if (roleDto == null)
                return BadRequest(new { message = "Datos del rol no válidos." });

            var success = await _roleService.UpdateRoleAsync(id, roleDto);
            if (!success)
                return NotFound(new { message = "Rol no encontrado." });

            return NoContent();
        }

        // DELETE: api/role/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var success = await _roleService.DeleteRoleAsync(id);
            if (!success)
                return NotFound(new { message = "Rol no encontrado." });

            return NoContent();
        }
    }
}
