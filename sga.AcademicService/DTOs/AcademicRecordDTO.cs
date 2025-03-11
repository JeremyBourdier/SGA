namespace sga.AcademicService.DTOs;

public class AcademicRecordDTO
{
    public int Id { get; set; }
    public double? Average { get; set; }
    public string Term { get; set; } = string.Empty;
    public int StudentId { get; set; }
}
