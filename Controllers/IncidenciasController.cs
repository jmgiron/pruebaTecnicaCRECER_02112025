using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace IncidenciasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidenciasController : ControllerBase
{
    private readonly string _conn;

    public IncidenciasController(IConfiguration config)
    {
        _conn = config.GetConnectionString("OracleConn");
    }

    // GET: api/incidencias
    [HttpGet]
    public IActionResult GetIncidencias()
    {
        using var cn = new OracleConnection(_conn);
        cn.Open();

        using var cmd = new OracleCommand("SELECT * FROM INCIDENCIA", cn);

        var reader = cmd.ExecuteReader();

        var result = new List<object>();

        while (reader.Read())
        {
            result.Add(new
            {
                Id = reader["ID"],
                Titulo = reader["TITULO"],
                Descripcion = reader["DESCRIPCION"],
                CategoriaId = reader["CATEGORIAID"],
                Severidad = reader["SEVERIDAD"],
                Estado = reader["ESTADO"],
                FechaRegistro = reader["FECHAREGISTRO"]
            });
        }

        return Ok(result);
    }

    // GET: api/incidencias/5
    [HttpGet("{id}")]
    public IActionResult GetIncidencia(int id)
    {
        using var cn = new OracleConnection(_conn);
        cn.Open();

        using var cmd = new OracleCommand("SELECT * FROM INCIDENCIA WHERE ID = :id", cn);
        cmd.Parameters.Add("id", id);

        using var reader = cmd.ExecuteReader();

        if (!reader.Read())
            return NotFound("Incidencia no encontrada");

        var result = new
        {
            Id = reader["ID"],
            Titulo = reader["TITULO"],
            Descripcion = reader["DESCRIPCION"],
            CategoriaId = reader["CATEGORIAID"],
            Severidad = reader["SEVERIDAD"],
            Estado = reader["ESTADO"],
            FechaRegistro = reader["FECHAREGISTRO"]
        };

        return Ok(result);
    }

    // POST: api/incidencias
    [HttpPost]
    public IActionResult Crear([FromBody] dynamic model)
    {
        using var cn = new OracleConnection(_conn);
        cn.Open();

        using var cmd = new OracleCommand("sp_RegistrarIncidencia", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("Titulo", model.Titulo.ToString());
        cmd.Parameters.Add("Descripcion", model.Descripcion.ToString());
        cmd.Parameters.Add("CategoriaId", int.Parse(model.CategoriaId.ToString()));
        cmd.Parameters.Add("Severidad", model.Severidad.ToString());

        var id = cmd.ExecuteScalar();

        return Ok(new { Id = id });
    }

    // PUT: api/incidencias/5
    [HttpPut("{id}")]
    public IActionResult ActualizarEstado(int id, [FromBody] dynamic model)
    {
        using var cn = new OracleConnection(_conn);
        cn.Open();

        using var cmd = new OracleCommand(
            "UPDATE INCIDENCIA SET ESTADO = :estado WHERE ID = :id", cn
        );

        cmd.Parameters.Add("estado", model.Estado.ToString());
        cmd.Parameters.Add("id", id);

        var rows = cmd.ExecuteNonQuery();

        if (rows == 0)
            return NotFound("Incidencia no encontrada");

        return Ok(new { Mensaje = "Estado actualizado" });
    }

    // DELETE: api/incidencias/5
    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        using var cn = new OracleConnection(_conn);
        cn.Open();

        using var cmd = new OracleCommand("DELETE FROM INCIDENCIA WHERE ID = :id", cn);
        cmd.Parameters.Add("id", id);

        var rows = cmd.ExecuteNonQuery();

        if (rows == 0)
            return NotFound("Incidencia no encontrada");

        return Ok(new { Mensaje = "Incidencia eliminada" });
    }
}
