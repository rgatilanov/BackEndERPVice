using Libreria.ERP.Catalogos;
using Libreria.ERP.Catalogos.Interfaces;
using Libreria.ERP.Catalogos.Models;
using Libreria.ERP.Catalogos.Services;
using Libreria.ERP.Catalogos.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.Common;

namespace ERP_WebAPI.Controllers.API
{
    public class CatalogoAPIController : ControllerBase
    {
        //[Authorize]
        ///https://localhost:5001/api/Catalogo/ConsultarCiudades?IdEstado=14
        [HttpGet]
        [Route("api/Catalogo/ConsultarCiudades")]
        public List<Ciudad> ConsultarCiudades(int IdEstado)
        {
            List<Ciudad> lstModel = new List<Ciudad>();
            using (ICiudadService iObj = FactorizadorCatalogo.Inicializar(Libreria.ERP.Configuracion.EServer.LOCAL_SQL))
            {
                return lstModel = iObj.ConsultarCiudades(IdEstado);
            }

            throw new Exception("Error en método");
        }

    }
}
