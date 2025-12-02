namespace IncidenciasAPI.DTOs;

public class ActualizarEstadoDTO
{
    public int IncidenciaId { get; set; }
    public string EstadoNuevo { get; set; } = string.Empty;
    public string Comentario { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
}
