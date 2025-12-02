using Incidencias.Application.DTO;
using Incidencias.Application.Interfaces;
using Incidencias.Infrastructure;

namespace Incidencias.Application.Services;
public class IncidenciaService : IIncidenciaService {
 private readonly IIncidenciaRepository _repo;
 public IncidenciaService(IIncidenciaRepository repo){ _repo=repo; }
 public Task<int> CrearAsync(CrearIncidenciaDTO dto)=> _repo.CrearAsync(dto);
}