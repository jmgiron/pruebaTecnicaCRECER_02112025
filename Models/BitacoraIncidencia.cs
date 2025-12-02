namespace IncidenciasAPI.Models;

public class BitacoraIncidencia
{
    public int Id { get; set; }
    public int IncidenciaId { get; set; }
    public string Usuario { get; set; } = string.Empty;
    public DateTime FechaHora { get; set; }
    public string EstadoAnterior { get; set; } = string.Empty;
    public string EstadoNuevo { get; set; } = string.Empty;
    public string Comentario { get; set; } = string.Empty;
    public string Accion { get; set; } = string.Empty;
}
