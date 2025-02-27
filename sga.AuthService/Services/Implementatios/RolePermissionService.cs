using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using sga.AuthService.DTOs;
using sga.AuthService.Repositories.Interfaces;
using sga.AuthService.Services.Interfaces;
using sga.Data.Entities;

namespace sga.AuthService.Services.Implementations
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRolePermissionRepository _repository;
        private readonly IMapper _mapper;

        public RolePermissionService(IRolePermissionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RolePermissionDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<RolePermissionDTO>>(list);
        }

        public async Task<RolePermissionDTO?> GetByIdsAsync(int roleId, int permissionId)
        {
            var entity = await _repository.GetByIdsAsync(roleId, permissionId);
            return entity == null ? null : _mapper.Map<RolePermissionDTO>(entity);
        }

        public async Task<bool> AddAsync(RolePermissionDTO dto)
        {
            var entity = _mapper.Map<RolePermission>(dto);
            return await _repository.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(int roleId, int permissionId)
        {
            return await _repository.DeleteAsync(roleId, permissionId);
        }
    }
}
