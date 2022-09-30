using Libreria.Conexion;
using Libreria.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.ERP.Configuracion
{
    public class BridgeDBConnection<T>
    {
        public static DbConnection Create(string ConnectionString, eProveedorDB DB)
        {
            return Factorizador.Create(ConnectionString, DB);
        }
    }
}
