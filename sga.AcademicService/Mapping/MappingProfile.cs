using AutoMapper;
using sga.AcademicService.DTOs;
using sga.Data.Entities;
using sga.Data.Entities.AcademicService;

namespace sga.AcademicService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
        }
    }
}
