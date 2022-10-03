using Dapper;
using Libreria.ERP.Catalogos.Models;
using Libreria.ERP.Catalogos.Services.Interfaces;
using Libreria.ERP.Configuracion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.ERP.Catalogos.Controllers
{
    public class CatalogoController : ICiudadService, IDisposable
    {
        EServer _server = EServer.UDEFINED;
        Dapper.DynamicParameters _parameters = new Dapper.DynamicParameters();
        DbConnection _conn;
       
        public CatalogoController(DbConnection conn, EServer server = EServer.UDEFINED)
        {
            _conn = conn;
            _server = server;
        }

        public List<Ciudad> ConsultarCiudades(int IdEstado)
        {
            List<Ciudad> lstResultado = new List<Ciudad>();
            try
            {
                switch (_server)
                {
                    case EServer.UDEFINED:
                        break;
                    case EServer.AZURE_SQL:
                    case EServer.LOCAL_SQL:
                        //https://stackoverflow.com/questions/50373574/example-of-dapper-query-with-n-number-of-navigation-properties
                        var sql = @"dbo.pa_Ciudades_Consultar";
                        var dpParametros = new DynamicParameters();
                        dpParametros.Add("@IdEstado", IdEstado);

                        var types = new[] { typeof(Ciudad), typeof(Estado), typeof(Pais)};
                        Func<object[], Ciudad> mapper = (objects) =>
                        {
                            var board = (Ciudad)objects[0];
                            board.Estado = (Estado)objects[1];
                            board.Estado.Pais = (Pais)objects[2];
                            return board;
                        };

                        /* var resultado = _conn.Query<Ciudad, Estado, Pais, Ciudad>(
                             sql, (ciudad, estado, pais) =>
                             {
                                 ciudad.Estado = estado;
                                 ciudad.Estado.Pais = pais;

                                 lstResultado.Add(ciudad);
                                 return ciudad;
                             },
                        */
                        var resultado = _conn.Query<Ciudad>(
                            sql, types, mapper, dpParametros, null, true, splitOn: "IdEstado,IdPais", 2000, commandType: CommandType.StoredProcedure);

                        return (List<Ciudad>)resultado;

               //mapper,dpParametros, commandType: CommandType.StoredProcedure
               //, splitOn: "IdEstado,IdPais");
                        break;
                };
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _conn.Dispose();
            }
            return lstResultado;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
