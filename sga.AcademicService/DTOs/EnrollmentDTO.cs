using System;

namespace sga.AcademicService.DTOs;

public class EnrollmentDTO
{
    public int Id { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Term { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty; // Añadido correctamente

    public int StudentId { get; set; }
    public int CourseId { get; set; }
}
