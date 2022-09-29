using Libreria.Conexion;
using Libreria.Conexion.Interfaces;
using Libreria.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.ERP.Configuracion
{
    public class BridgeDBConnection<T>
    {
        public static IConexionDB<T> Create(string ConnectionString, eProveedorDB DB)
        {
            return Factorizador<T>.Create(ConnectionString, DB);
        }
    }
}
