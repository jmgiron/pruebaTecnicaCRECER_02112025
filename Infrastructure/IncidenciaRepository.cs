
using Oracle.ManagedDataAccess.Client;
using Incidencias.Application.DTO;

namespace Incidencias.Infrastructure;
public class IncidenciaRepository : IIncidenciaRepository {
    private readonly string _conn;
    public IncidenciaRepository(IConfiguration config) { _conn=config.GetConnectionString("Oracle"); }

    public async Task<int> CrearAsync(CrearIncidenciaDTO dto) {
        using var con = new OracleConnection(_conn);
        await con.OpenAsync();
        using var cmd = new OracleCommand("sp_RegistrarIncidencia", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add("pTitulo", OracleDbType.NVarchar2).Value = dto.Titulo;
        cmd.Parameters.Add("pDescripcion", OracleDbType.Clob).Value = dto.Descripcion;
        cmd.Parameters.Add("pCategoriaId", OracleDbType.Int32).Value = dto.CategoriaId;
        cmd.Parameters.Add("pSeveridad", OracleDbType.NVarchar2).Value = dto.Severidad;
        cmd.Parameters.Add("P_RESULT", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;

        await cmd.ExecuteNonQueryAsync();
        return int.Parse(cmd.Parameters["P_RESULT"].Value.ToString());
    }
}
