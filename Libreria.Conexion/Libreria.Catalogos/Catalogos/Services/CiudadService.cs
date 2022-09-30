using Libreria.Conexion.Interfaces;
using Libreria.ERP.Catalogos.Models;
using Libreria.ERP.Catalogos.Services.Interfaces;
using Libreria.ERP.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.ERP.Catalogos.Services
{
    public class CiudadService : ICiudadService, IDisposable
    {
        private readonly ICiudadService _metodos;
        EServer _server = EServer.UDEFINED;
        IConexionDB<Ciudad> _conn;
        public CiudadService(IConexionDB<Ciudad> conn, ICiudadService metodos, EServer server = EServer.UDEFINED)
        {
            _conn = conn;
            _server = server;
            _metodos = metodos;
        } 
        public List<Ciudad> ConsultarCiudades(IConexionDB<Ciudad> conn, int IdEstado)
        {
           return _metodos.ConsultarCiudades(conn, IdEstado); 
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
