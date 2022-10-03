using Libreria.Conexion.Interfaces;
using Libreria.ERP.Catalogos.Models;
using Libreria.ERP.Catalogos.Services.Interfaces;
using Libreria.ERP.Configuracion;
using System;
using System.Collections.Generic;
using System.Data;
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
        IConexionDB<Ciudad> _conn;
        public CatalogoController()
        { }
        public CatalogoController(IConexionDB<Ciudad> conn, EServer server = EServer.UDEFINED)
        {
            _conn = conn;
            _server = server;
        }

        public List<Ciudad> ConsultarCiudades(int IdEstado)
        {
            List<Ciudad> lstResultado = new List<Ciudad>();
            IConexionDB<Ciudad> _conexion = _conn;
            try
            {
                switch (_server)
                {
                    case EServer.UDEFINED:
                        break;
                    case EServer.AZURE_SQL:
                    case EServer.LOCAL_SQL:
                        _parameters.Add("@IdEstado", IdEstado, DbType.Int32, ParameterDirection.Input);
                        _conexion.PrepararProcedimiento("dbo.[pa_Ciudades_Consultar]", _parameters);

                        //Esto lo encontré en: https://stackoverflow.com/questions/50373574/example-of-dapper-query-with-n-number-of-navigation-properties
                        var types = new[] { typeof(Ciudad), typeof(Estado), typeof(Pais) };
                        Func<object[], Ciudad> mapper = (objects) =>
                        {
                            var board = (Ciudad)objects[0];
                            board.Estado = (Estado)objects[1];
                            board.Estado.Pais = (Pais)objects[2];
                            return board;
                        };

                        lstResultado = (List<Ciudad>)_conexion.Query(types, mapper, "IdEstado,IdPais");

                        //lstResultado = (List<Ciudad>)_conexion.Query();
                        break;
                    default:
                        break;
                }
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
                _conexion.Dispose();
            }
            return lstResultado;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
