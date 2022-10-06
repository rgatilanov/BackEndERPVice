using Dapper;
using Libreria.Conexion.Interfaces;
using Libreria.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Libreria.Conexion.Conexiones
{
    internal class MySql<T> : IConexionDB<T>
    {
        public static MySql<T> Conectar(string strConnectionString)
        {
            throw new NotImplementedException(); 
        }
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

        public IEnumerable<T> Query(Type[] types, Func<object[], T> map, string splitOn)
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
