using System.ComponentModel.DataAnnotations;

namespace IncidenciasAPI.DTOs
{
    public class CrearIncidenciaDTO
    {
        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [MinLength(10, ErrorMessage = "La descripción debe tener al menos 10 caracteres.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La categoría debe ser válida.")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "La severidad es obligatoria.")]
        [RegularExpression("^(Baja|Media|Alta)$", ErrorMessage = "La severidad debe ser 'Baja', 'Media' o 'Alta'.")]
        public string Severidad { get; set; } = string.Empty;
    }
}
