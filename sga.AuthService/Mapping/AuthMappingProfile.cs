using AutoMapper;
using sga.AuthService.DTOs;
using sga.Data.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace sga.AuthService.Mapping
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            // Configura el mapeo entre la entidad User y el DTO UserDTO
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Permission, PermissionDTO>().ReverseMap();
            CreateMap<RolePermission, RolePermissionDTO>().ReverseMap();
            CreateMap<UserRole, UserRoleDTO>().ReverseMap();
        }
    }
}
