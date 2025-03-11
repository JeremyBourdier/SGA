namespace sga.AcademicService.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Department { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public DateTime? HireDate { get; set; }
    }
}
