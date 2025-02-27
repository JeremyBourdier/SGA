using Microsoft.AspNetCore.Mvc;
using sga.AuthService.DTOs;
using sga.AuthService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        // GET: api/permission
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionDTO>>> GetAllPermissions()
        {
            var perms = await _permissionService.GetAllPermissionsAsync();
            return Ok(perms);
        }

        // GET: api/permission/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionDTO>> GetPermission(int id)
        {
            var perm = await _permissionService.GetPermissionByIdAsync(id);
            if (perm == null)
                return NotFound(new { message = "Permiso no encontrado." });

            return Ok(perm);
        }

        // POST: api/permission
        [HttpPost]
        public async Task<IActionResult> AddPermission([FromBody] PermissionDTO dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Datos del permiso no válidos." });

            var success = await _permissionService.AddPermissionAsync(dto);
            if (!success)
                return BadRequest(new { message = "No se pudo crear el permiso." });

            return Ok(dto);
        }

        // PUT: api/permission/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermission(int id, [FromBody] PermissionDTO dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Datos del permiso no válidos." });

            var success = await _permissionService.UpdatePermissionAsync(id, dto);
            if (!success)
                return NotFound(new { message = "Permiso no encontrado." });

            return NoContent();
        }

        // DELETE: api/permission/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            var success = await _permissionService.DeletePermissionAsync(id);
            if (!success)
                return NotFound(new { message = "Permiso no encontrado." });

            return NoContent();
        }
    }
}
