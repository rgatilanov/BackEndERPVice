using Libreria.ERP.Catalogos.Models;
using Libreria.ERP.Catalogos.Services;
using Libreria.ERP.Catalogos.Services.Interfaces;
using Libreria.ERP.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.ERP.Catalogos
{
    public static class FactorizadorCatalogo
    {
        public static ICiudadService Inicializar(EServer server)
        {
            ICiudadService nuevoMotor = null;

            return server switch
            {
                EServer.UDEFINED => throw new NullReferenceException(),
                EServer.LOCAL_SQL => new CiudadService(BridgeDBConnection<Ciudad>.Create(ConnectionStrings.LocalServer_SQLServer, Conexion.Models.eProveedorDB.Sql), nuevoMotor, server),
                //EServer.AZURE_SQL => new CiudadService(BridgeDBConnection<Ciudad>.Create(ConnectionStrings.Azure_SQLServer, Conexion.Models.eProveedorDB.Sql), nuevoMotor),
               _ => throw new NotImplementedException(),
            };
            
        }
    }
}
