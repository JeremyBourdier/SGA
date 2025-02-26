using System.ComponentModel.DataAnnotations;

namespace sga.AcademicService.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "El código no puede superar los 10 caracteres.")]
        public string Code { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Name { get; set; }

        [Range(1, 10, ErrorMessage = "Los créditos deben estar entre 1 y 10.")]
        public int Credits { get; set; }
    }
}
