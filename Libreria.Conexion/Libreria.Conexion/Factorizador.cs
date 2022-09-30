using Libreria.Conexion.Conexiones;
using Libreria.Conexion.Herramientas;
using Libreria.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Conexion
{
    public class Factorizador
    {
        public static DbConnection Create(string ConnectionString, eProveedorDB DB)
        {
            switch (DB)
            {
                case eProveedorDB.Sql:
                    SqlServer _sqlServer = new SqlServer(EncryptTool.Decrypt(ConnectionString));
                    return _sqlServer.Open(ConnectionString);
                   
                case eProveedorDB.MySql:
                    throw new NotImplementedException();
                case eProveedorDB.PostgreSQL:
                    throw new NotImplementedException();
                case eProveedorDB.Oracle:
                    throw new NotImplementedException();
                case eProveedorDB.MariDB:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
