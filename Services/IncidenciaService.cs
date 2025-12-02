using IncidenciasAPI.DTOs;
using IncidenciasAPI.Repositories;

namespace IncidenciasAPI.Services;

public class IncidenciaService : IIncidenciaService
{
    private readonly IIncidenciaRepository _incidenciaRepository;

    public IncidenciaService(IIncidenciaRepository incidenciaRepository)
    {
        _incidenciaRepository = incidenciaRepository;
    }

    public Task<int> CrearIncidenciaAsync(CrearIncidenciaDTO dto)
    {
        return _incidenciaRepository.CrearIncidenciaAsync(dto);
    }
}
