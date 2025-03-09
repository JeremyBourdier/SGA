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
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Grade, GradeDTO>().ReverseMap();
            CreateMap<Enrollment, EnrollmentDTO>().ReverseMap();
            CreateMap<Degree, DegreeDTO>().ReverseMap();
            CreateMap<CourseTeacher, CourseTeacherDTO>().ReverseMap();
            CreateMap<Attendance, AttendanceDTO>().ReverseMap();
        }
    }
}
