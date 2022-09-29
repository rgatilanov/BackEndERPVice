using Libreria.Conexion.Interfaces;
using Libreria.ERP.Catalogos.Models;
using Libreria.ERP.Catalogos.Services.Interfaces;
using Libreria.ERP.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.ERP.Catalogos.Services
{
    public class CatalogoService : ICatalogoService, IDisposable
    {
        private readonly ICatalogoService _metodos;
        EServer _server = EServer.UDEFINED;
        public CatalogoService(ICatalogoService metodos, EServer server)
        {
            _metodos = metodos;
            _server = server;
        } 
        public List<Ciudad> ConsultarCiudades(IConexionDB<Ciudad> conexion, int IdEstado)
        {
            switch (_server)
            {
                case EServer.UDEFINED:
                    break;
                case EServer.AZURE_SQL:
                    return _metodos.ConsultarCiudades(BridgeDBConnection<Ciudad>.Create(ConnectionStrings.Azure_SQLServer, Conexion.Models.eProveedorDB.Sql), IdEstado);
                case EServer.LOCAL_SQL:
                    return _metodos.ConsultarCiudades(BridgeDBConnection<Ciudad>.Create(ConnectionStrings.LocalServer_SQLServer, Conexion.Models.eProveedorDB.Sql), IdEstado);
                default:
                    break;
            }
            throw new NotImplementedException();    
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
