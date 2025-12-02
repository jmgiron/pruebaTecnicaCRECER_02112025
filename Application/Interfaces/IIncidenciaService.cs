using Incidencias.Application.DTO;

namespace Incidencias.Application.Interfaces;
public interface IIncidenciaService {
 Task<int> CrearAsync(CrearIncidenciaDTO dto);
}