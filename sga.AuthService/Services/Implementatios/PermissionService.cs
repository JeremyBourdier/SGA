using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using sga.AuthService.DTOs;
using sga.AuthService.Repositories.Interfaces;
using sga.AuthService.Services.Interfaces;
using sga.Data.Entities;

namespace sga.AuthService.Services.Implementations
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepo;
        private readonly IMapper _mapper;

        public PermissionService(IPermissionRepository permissionRepo, IMapper mapper)
        {
            _permissionRepo = permissionRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionDTO>> GetAllPermissionsAsync()
        {
            var perms = await _permissionRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<PermissionDTO>>(perms);
        }

        public async Task<PermissionDTO?> GetPermissionByIdAsync(int id)
        {
            var perm = await _permissionRepo.GetByIdAsync(id);
            return perm == null ? null : _mapper.Map<PermissionDTO>(perm);
        }

        public async Task<bool> AddPermissionAsync(PermissionDTO dto)
        {
            if (dto == null) return false;

            var entity = _mapper.Map<Permission>(dto);
            return await _permissionRepo.AddAsync(entity);
        }

        public async Task<bool> UpdatePermissionAsync(int id, PermissionDTO dto)
        {
            if (dto == null) return false;

            var existing = await _permissionRepo.GetByIdAsync(id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);
            return await _permissionRepo.UpdateAsync(existing);
        }

        public async Task<bool> DeletePermissionAsync(int id)
        {
            var existing = await _permissionRepo.GetByIdAsync(id);
            if (existing == null) return false;

            return await _permissionRepo.DeleteAsync(id);
        }
    }
}
