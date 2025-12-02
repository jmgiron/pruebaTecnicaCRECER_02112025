namespace Incidencias.Domain;
public class Incidencia {
 public int Id {get;set;}
 public string Titulo {get;set;} = "";
 public string Descripcion {get;set;} = "";
 public int CategoriaId {get;set;}
 public string Severidad {get;set;} = "";
 public string Estado {get;set;} = "";
 public DateTime FechaRegistro {get;set;}
}