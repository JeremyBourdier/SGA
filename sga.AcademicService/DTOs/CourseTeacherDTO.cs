namespace sga.AcademicService.DTOs;

public class CourseTeacherDTO
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
    public DateTime? AssignmentDate { get; set; }
}
