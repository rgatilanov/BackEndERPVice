using Libreria.Conexion.Interfaces;
using Libreria.ERP.Catalogos.Controllers;
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

        public CiudadService(IConexionDB<Ciudad> conn, ICiudadService metodos, EServer server = EServer.UDEFINED)
        {
            _metodos = new CatalogoController(conn, server);
        } 
        public List<Ciudad> ConsultarCiudades(int IdEstado)
        {
           return _metodos.ConsultarCiudades(IdEstado); 
        }

        public void Dispose()
        {
            
        }
    }
}
