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
        
        public List<Ciudad> ConsultarCiudades(IConexionDB<Ciudad> conn, int IdEstado)
        {
            List<Ciudad> lstResultado = new List<Ciudad>();
            IConexionDB<Ciudad> _conexion = conn;
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
                        lstResultado = (List<Ciudad>)_conexion.Query();
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
