namespace sga.AcademicService.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DegreeId { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public DateTime AdmissionDate { get; set; }
    }
}
