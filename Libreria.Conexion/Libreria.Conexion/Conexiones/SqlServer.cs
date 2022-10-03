using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Conexion.Conexiones
{
    internal class SqlServer 
    {
        #region Constructor estático y variables globales
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SqlConnection _clsSqlConnection = null;
        private string _connectionString;
        public SqlServer(string connectionString)
        {
            _clsSqlConnection = new SqlConnection(connectionString);
            _connectionString = connectionString;
        }

        public void Close()
        {
            _clsSqlConnection.Close();
        }

        public SqlConnection Open(string encryptCnn)
        {
            try
            {
                _clsSqlConnection.Open();
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _clsSqlConnection;
        }
        
        #endregion

#region IDisposable Members

        public void Dispose()
        {
            try
            {
                Close();
                _clsSqlConnection.Dispose();
            }
            catch { }
        }

        #endregion
    }
}
