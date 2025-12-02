namespace Incidencias.Application.DTO;
public class CrearIncidenciaDTO {
 public string Titulo {get;set;} = "";
 public string Descripcion {get;set;} = "";
 public int CategoriaId {get;set;}
 public string Severidad {get;set;} = "";
}