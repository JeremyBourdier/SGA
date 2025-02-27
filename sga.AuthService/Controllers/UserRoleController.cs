using Microsoft.AspNetCore.Mvc;
using sga.AuthService.DTOs;
using sga.AuthService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoleDTO>>> GetAll()
        {
            return Ok(await _userRoleService.GetAllAsync());
        }

        [HttpGet("{userId}/{roleId}")]
        public async Task<ActionResult<UserRoleDTO>> GetById(int userId, int roleId)
        {
            var userRole = await _userRoleService.GetByIdAsync(userId, roleId);
            if (userRole == null) return NotFound();
            return Ok(userRole);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRoleDTO userRoleDto)
        {
            await _userRoleService.AddAsync(userRoleDto);
            return CreatedAtAction(nameof(GetById), new { userId = userRoleDto.UserID, roleId = userRoleDto.RoleID }, userRoleDto);
        }

        [HttpDelete("{userId}/{roleId}")]
        public async Task<IActionResult> Delete(int userId, int roleId)
        {
            await _userRoleService.DeleteAsync(userId, roleId);
            return NoContent();
        }
    }
}
