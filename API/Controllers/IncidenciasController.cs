using Microsoft.AspNetCore.Mvc;
using Incidencias.Application.DTO;
using Incidencias.Application.Interfaces;

namespace Incidencias.API.Controllers;
[ApiController]
[Route("api/incidencias")]
public class IncidenciasController : ControllerBase {
 private readonly IIncidenciaService _s;
 public IncidenciasController(IIncidenciaService s){_s=s;}

 [HttpPost]
 public async Task<IActionResult> Crear(CrearIncidenciaDTO dto){
   var id=await _s.CrearAsync(dto);
   return Ok(new {id});
 }
}