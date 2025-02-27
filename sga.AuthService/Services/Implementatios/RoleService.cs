using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using sga.AuthService.DTOs;
using sga.AuthService.Repositories.Interfaces;
using sga.AuthService.Services.Interfaces;
using sga.Data.Entities;

namespace sga.AuthService.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(roles);
        }

        public async Task<RoleDTO?> GetRoleByIdAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            return role == null ? null : _mapper.Map<RoleDTO>(role);
        }

        public async Task<bool> AddRoleAsync(RoleDTO roleDto)
        {
            if (roleDto == null) return false;

            var entity = _mapper.Map<Role>(roleDto);
            return await _roleRepository.AddAsync(entity);
        }

        public async Task<bool> UpdateRoleAsync(int id, RoleDTO roleDto)
        {
            if (roleDto == null) return false;

            var existing = await _roleRepository.GetByIdAsync(id);
            if (existing == null) return false;

            _mapper.Map(roleDto, existing);
            return await _roleRepository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var existing = await _roleRepository.GetByIdAsync(id);
            if (existing == null) return false;

            return await _roleRepository.DeleteAsync(id);
        }
    }
}
