using Dapper;
using Libreria.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Conexion.Interfaces
{
    public interface IConexionDB<T>: IDisposable
    {
        void PrepararProcedimiento(string nombreProcedimiento, DynamicParameters dynParameters, CommandType enuTipoComando = CommandType.StoredProcedure);
        long ExecuteDapper();
        T QueryFirstOrDefaultDapper();
        object QueryFirstOrDefaultDapper(TipoDato tipo);
        IEnumerable<T> Query();
        IEnumerable<T> Query(Type[] types, Func<object[], T> map, string splitOn);
    }
}
