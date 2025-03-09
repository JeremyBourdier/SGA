using System;

namespace sga.AcademicService.DTOs;

public class AttendanceDTO
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime AttendanceDate { get; set; }
    public int EnrollmentId { get; set; }
}
