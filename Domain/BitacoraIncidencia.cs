namespace Incidencias.Domain;
public class BitacoraIncidencia {
 public int Id {get;set;}
 public int IncidenciaId {get;set;}
 public string Usuario {get;set;} = "";
 public DateTime FechaHora {get;set;}
 public string EstadoAnterior {get;set;} = "";
 public string EstadoNuevo {get;set;} = "";
 public string Comentario {get;set;} = "";
 public string Accion {get;set;} = "";
}