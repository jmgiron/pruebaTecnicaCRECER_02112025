using System.Data;
using IncidenciasAPI.DTOs;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace IncidenciasAPI.Repositories;

public class IncidenciaRepository : IIncidenciaRepository
{
    private readonly string _connectionString;

    public IncidenciaRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("OracleConnection")
                           ?? throw new InvalidOperationException("Connection string 'OracleConnection' not found.");
    }

    public async Task<int> CrearIncidenciaAsync(CrearIncidenciaDTO dto)
    {
        using var connection = new OracleConnection(_connectionString);
        await connection.OpenAsync();

        // Asumimos una tabla INCIDENCIA e ID generado por una secuencia y trigger.
        // Insertamos y obtenemos el ID con RETURNING.
        const string sql = @"
            INSERT INTO INCIDENCIA (TITULO, DESCRIPCION, CATEGORIA_ID, SEVERIDAD, ESTADO, FECHA_REGISTRO)
            VALUES (:Titulo, :Descripcion, :CategoriaId, :Severidad, 'Pendiente', SYSDATE)
            RETURNING ID INTO :Id";

        using var command = new OracleCommand(sql, connection);
        command.BindByName = true;

        command.Parameters.Add(":Titulo", OracleDbType.Varchar2, 200).Value = dto.Titulo;
        command.Parameters.Add(":Descripcion", OracleDbType.Clob).Value = dto.Descripcion;
        command.Parameters.Add(":CategoriaId", OracleDbType.Int32).Value = dto.CategoriaId;
        command.Parameters.Add(":Severidad", OracleDbType.Varchar2, 50).Value = dto.Severidad;

        var idParam = new OracleParameter(":Id", OracleDbType.Int32)
        {
            Direction = ParameterDirection.Output
        };
        command.Parameters.Add(idParam);

        await command.ExecuteNonQueryAsync();

        return Convert.ToInt32(idParam.Value);
    }
}
