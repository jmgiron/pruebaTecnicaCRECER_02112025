using Incidencias.Application.DTO;

namespace Incidencias.Infrastructure;
public interface IIncidenciaRepository {
 Task<int> CrearAsync(CrearIncidenciaDTO dto);
}