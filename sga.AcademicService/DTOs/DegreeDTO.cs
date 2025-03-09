namespace sga.AcademicService.DTOs;

public class DegreeDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? Duration { get; set; }
    public string Modality { get; set; } = string.Empty;
}
