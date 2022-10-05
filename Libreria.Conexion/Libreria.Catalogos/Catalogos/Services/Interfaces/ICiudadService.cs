using Libreria.Conexion.Interfaces;
using Libreria.ERP.Catalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.ERP.Catalogos.Services.Interfaces
{
    public interface ICiudadService: IDisposable
    {
        public List<Ciudad> ConsultarCiudades(int IdEstado);
        public long InsertarCiudades(Ciudad ciudad);

        #region IDisposable Members
        public void Dispose()
        {
            try
            {
                //sqlCon.Dispose();
                //sqlCon = null;
                //_Parametros.Clear();
                //media.Close();
                //media = null;
            }
            catch { }
        }
        #endregion
    }
}
