using System.ComponentModel.DataAnnotations;

namespace sga.AcademicService.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "El código no puede superar los 10 caracteres.")]
        public string Code { get; set; } = string.Empty;  

        [Required]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Name { get; set; } = string.Empty;  

        [Range(0, 10, ErrorMessage = "Los créditos deben estar entre 0 y 5.")]
        public int Credits { get; set; }
    }
}
