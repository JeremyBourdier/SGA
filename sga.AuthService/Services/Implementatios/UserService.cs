using AutoMapper;
using sga.AuthService.DTOs;
using sga.AuthService.Repositories.Interfaces;
using sga.AuthService.Services.Interfaces;
using sga.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sga.AuthService.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> AddUserAsync(UserDTO userDto)
        {
            if (userDto == null)
                return false;

            var user = _mapper.Map<User>(userDto);
            return await _userRepository.AddAsync(user);
        }

        public async Task<bool> UpdateUserAsync(int id, UserDTO userDto)
        {
            if (userDto == null)
                return false;

            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                return false;

            // Actualiza las propiedades con AutoMapper
            _mapper.Map(userDto, existingUser);
            return await _userRepository.UpdateAsync(existingUser);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                return false;

            return await _userRepository.DeleteAsync(id);
        }
    }
}
