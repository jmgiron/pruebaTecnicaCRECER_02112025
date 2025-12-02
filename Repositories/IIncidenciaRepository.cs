using IncidenciasAPI.DTOs;

namespace IncidenciasAPI.Repositories;

public interface IIncidenciaRepository
{
    Task<int> CrearIncidenciaAsync(CrearIncidenciaDTO dto);
}
