using Dapper;
using Libreria.Conexion.Interfaces;
using Libreria.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Conexion.Conexiones
{
    internal class MySql<T> : IConexionDB<T>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public long ExecuteDapper()
        {
            throw new NotImplementedException();
        }

        public void PrepararProcedimiento(string nombreProcedimiento, DynamicParameters dynParameters, CommandType enuTipoComando = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query()
        {
            throw new NotImplementedException();
        }

        public T QueryFirstOrDefaultDapper()
        {
            throw new NotImplementedException();
        }

        public object QueryFirstOrDefaultDapper(TipoDato tipo)
        {
            throw new NotImplementedException();
        }
    }
}
