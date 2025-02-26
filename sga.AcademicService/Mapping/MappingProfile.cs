using AutoMapper;
using sga.AcademicService.DTOs;
using sga.Data.Entities;

namespace sga.AcademicService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
        }
    }
}
