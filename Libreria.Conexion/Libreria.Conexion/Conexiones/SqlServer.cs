using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria.Conexion.Interfaces;

namespace Libreria.Conexion.Conexiones
{
    internal class SqlServer<T> : IConexionDB<T>
    {
        #region Constructor estático y variables globales
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SqlConnection _clsSqlConnection = null;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]

        bool _blnConectado = false;
        bool _blnPreparado = false;
        string _nombreProcedimiento = string.Empty;
        DynamicParameters _dynParameters;
        CommandType _commandType;
        int _timeOut = 12000;

        private SqlServer()
        {

        }


        public static SqlServer<T> Conectar(string strConnectionString)
        {
            SqlServer<T> modSql = new SqlServer<T>()
            {
                _clsSqlConnection = new SqlConnection(strConnectionString)
            };

            try
            {
                modSql._clsSqlConnection.Open();
                modSql._blnConectado = true;
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return modSql;
        }
        #endregion


        #region Métodos públicos

        public void PrepararProcedimiento(string nombreProcedimiento, DynamicParameters dynParameters, CommandType enuTipoComando = CommandType.StoredProcedure)
        {
            if (_blnConectado)
            {
                _nombreProcedimiento = nombreProcedimiento;
                _dynParameters = dynParameters;
                _commandType = enuTipoComando;
                _blnPreparado = true;
            }
            else
            {
                throw new Exception("No hay conexion con la bd");
            }
        }

        public long ExecuteDapper()
        {
            if (_blnPreparado)
            {
                _blnPreparado = false;
                return _clsSqlConnection.Execute(_nombreProcedimiento, _dynParameters, null, _timeOut, _commandType);
            }
            else
            {
                _blnPreparado = false;
                throw new Exception("Procedimiento no preparado");
            }
        }

        public T QueryFirstOrDefaultDapper()
        {
            if (_blnPreparado)
            {
                _blnPreparado = false;
                return _clsSqlConnection.QueryFirstOrDefault<T>(_nombreProcedimiento, _dynParameters, null, _timeOut, _commandType);
            }
            else
            {
                _blnPreparado = false;
                throw new Exception("Procedimiento no preparado");
            }
        }
        public object QueryFirstOrDefaultDapper(Models.TipoDato tipo)
        {
            if (_blnPreparado)
            {
                _blnPreparado = false;
                return tipo == Models.TipoDato.Numerico ? _clsSqlConnection.QueryFirstOrDefault<long>(_nombreProcedimiento, _dynParameters, null, _timeOut, _commandType) : _clsSqlConnection.QueryFirstOrDefault<string>(_nombreProcedimiento, _dynParameters, null, _timeOut, _commandType);
            }
            else
            {
                _blnPreparado = false;
                throw new Exception("Procedimiento no preparado");
            }
        }
        public IEnumerable<T> Query()
        {
            if (_blnPreparado)
            {
                _blnPreparado = false;
                return _clsSqlConnection.Query<T>(_nombreProcedimiento, _dynParameters, null, true, _timeOut, _commandType);
            }
            else
            {
                _blnPreparado = false;
                throw new Exception("Procedimiento no preparado");
            }
        }
        public IEnumerable<T> Query(Type[] types, Func<object[], T> map,string splitOn)
        {
            if (_blnPreparado)
            {
                _blnPreparado = false;
                return _clsSqlConnection.Query<T>(_nombreProcedimiento,types,map, _dynParameters, null, true, splitOn, _timeOut, _commandType);
            }
            else
            {
                _blnPreparado = false;
                throw new Exception("Procedimiento no preparado");
            }
        }
        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                Desconectar();
                _clsSqlConnection.Dispose();
                _dynParameters = null;
                _blnPreparado = false;
            }
            catch { }
        }
        public void Desconectar()
        {
            _clsSqlConnection.Close();
        }

     

        #endregion
    }
}
