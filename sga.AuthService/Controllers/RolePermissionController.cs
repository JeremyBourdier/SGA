using Microsoft.AspNetCore.Mvc;
using sga.AuthService.DTOs;
using sga.AuthService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionService _service;

        public RolePermissionController(IRolePermissionService service)
        {
            _service = service;
        }

        // GET: api/rolepermission
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolePermissionDTO>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // GET: api/rolepermission/roleId/permissionId
        [HttpGet("{roleId}/{permissionId}")]
        public async Task<ActionResult<RolePermissionDTO>> GetByIds(int roleId, int permissionId)
        {
            var item = await _service.GetByIdsAsync(roleId, permissionId);
            if (item == null)
                return NotFound(new { message = "RolePermission no encontrado." });

            return Ok(item);
        }

        // POST: api/rolepermission
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RolePermissionDTO dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Datos no válidos." });

            var success = await _service.AddAsync(dto);
            if (!success)
                return BadRequest(new { message = "No se pudo asignar la relación Role-Permission." });

            return Ok(dto);
        }

        // DELETE: api/rolepermission/roleId/permissionId
        [HttpDelete("{roleId}/{permissionId}")]
        public async Task<IActionResult> Delete(int roleId, int permissionId)
        {
            var success = await _service.DeleteAsync(roleId, permissionId);
            if (!success)
                return NotFound(new { message = "RolePermission no encontrado." });

            return NoContent();
        }
    }
}
