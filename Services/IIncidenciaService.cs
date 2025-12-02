using IncidenciasAPI.DTOs;

namespace IncidenciasAPI.Services;

public interface IIncidenciaService
{
    Task<int> CrearIncidenciaAsync(CrearIncidenciaDTO dto);
}
