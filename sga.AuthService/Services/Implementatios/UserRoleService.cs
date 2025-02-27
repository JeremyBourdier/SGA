using AutoMapper;
using sga.AuthService.DTOs;
using sga.AuthService.Repositories.Interfaces;
using sga.AuthService.Services.Interfaces;
using sga.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Services.Implementations
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _repository;
        private readonly IMapper _mapper;

        public UserRoleService(IUserRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserRoleDTO>> GetAllAsync()
        {
            var userRoles = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserRoleDTO>>(userRoles);
        }

        public async Task<UserRoleDTO> GetByIdAsync(int userId, int roleId)
        {
            var userRole = await _repository.GetByIdAsync(userId, roleId);
            return _mapper.Map<UserRoleDTO>(userRole);
        }

        public async Task AddAsync(UserRoleDTO userRoleDto)
        {
            var userRole = _mapper.Map<UserRole>(userRoleDto);
            await _repository.AddAsync(userRole);
        }

        public async Task DeleteAsync(int userId, int roleId)
        {
            await _repository.DeleteAsync(userId, roleId);
        }
    }
}
