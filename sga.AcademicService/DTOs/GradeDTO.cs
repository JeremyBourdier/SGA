namespace sga.AcademicService.DTOs
{
    public class GradeDTO
    {
        public int Id { get; set; }
        public double? FinalScore { get; set; }
        public string EvaluationType { get; set; } // e.g. 'Partial', 'Homework', 'Final'
        public int EnrollmentId { get; set; }
    }
}
