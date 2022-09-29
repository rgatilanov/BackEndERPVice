using Libreria.Conexion.Conexiones;
using Libreria.Conexion.Herramientas;
using Libreria.Conexion.Interfaces;
using Libreria.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Conexion
{
    public class Factorizador<T>
    {
        public static IConexionDB<T> Create(string ConnectionString, eProveedorDB DB)
        {
            return DB switch
            {
                eProveedorDB.Sql => SqlServer<T>.Conectar(EncryptTool.Decrypt(ConnectionString)),
                eProveedorDB.MySql => MySql<T>.Conectar(EncryptTool.Decrypt(ConnectionString)),
                _ => throw new NotImplementedException()
            };
        }
    }
}
